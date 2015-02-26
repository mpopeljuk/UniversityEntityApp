using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.ComponentModel;
using DBModels;

namespace UniversityEntityApp
{
    class FormUpdateHelper
    {
        UnitOfWork uOW;

        public FormUpdateHelper() 
        {
            uOW = new UnitOfWork();
        }

        public DataTable ShowTable(string tableName)
        {
            DataTable result = new DataTable();

            switch (tableName)
            {
                case "Groups":
                    return convertToDatatable(
                        uOW.GroupRep.GetGroups().ToList());

                case "Subjects":
                    return convertToDatatable(
                        uOW.SubjectRep.GetSubjects().ToList());

                case "Students":
                    return convertToDatatable(
                        uOW.StudentRep.GetStudents().ToList());

                default:
                    return new DataTable();
            }
        }

        public DataTable ShowGroupToSubjectTable(Form1.TableNames tableName, string arg) 
        {
            int id = GetIdFromString(arg);
            if (tableName == Form1.TableNames.Subjects) //subject change
            {
                return convertToDatatable( uOW.GtsRep.GetGroupsForSubject(id).ToList() );
            }
            else if (tableName == Form1.TableNames.Groups) //group change
            {
                return convertToDatatable(uOW.GtsRep.GetSubjectsForGroup(id).ToList());
            }
            else
            {
                return new DataTable();
            }
        }
        
        /// <summary>
        /// Create a DataGridViewComboBoxColumn with items of table.
        /// </summary>
        /// <param name="tableName">Table name you want to get values. Can be only Subject or Student table. </param>
        /// <returns>DataGridViewComboBoxColumn with items formatted (<id>,<name>).</returns>
        public DataGridViewComboBoxColumn getRelationComboBox(string tableName)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            if (tableName == "Groups")
            {
                cmb.HeaderText = "Select " + tableName;

                DataTable dt = convertToDatatable(uOW.GroupRep.GetNameIdPair().ToList());

                foreach (DataRow item in dt.Rows)
                {
                    cmb.Items.Add(item["Name"] + "," + item["Id"]);
                }
            }
            else if (tableName == "Subjects")
            {
                cmb.HeaderText = "Select " + tableName;

                DataTable dt = convertToDatatable(uOW.SubjectRep.GetNameIdPair().ToList());

                foreach (DataRow item in dt.Rows)
                {
                    cmb.Items.Add(item["Name"] + "," + item["Id"]);
                }
            }
            else
            {
                cmb.HeaderText = "Empty";
            }

            cmb.FlatStyle = FlatStyle.Flat;
            return cmb;
        }
        
        /// <summary>
        /// Split with comma and returns last value as int. If failed - return 0.
        /// </summary>
        /// <param name="s">String you need to split.</param>
        /// <returns>Integer value. If failed - return 0.</returns>
        public int GetIdFromString(string s)
        {
            int result;

            string[] splitted = s.Split(',');

            if (!int.TryParse(splitted[splitted.Length - 1], out result))
            {
                result = 0;
            }

            return result;
        }
        
        /// <summary>
        /// Clone row from grid.
        /// </summary>
        /// <param name="row">Row you need to clone.</param>
        /// <returns>Cloned row.</returns>
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
        
        /// <summary>
        /// Check if row is allready in change list for not add it twice.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isInChangeList(DataGridView grid, object row)
        {
            foreach (DataGridViewRow item in grid.Rows)
            {
                if (item.Cells[0].Value == null)
                    return false;
                else if (item.Cells[0].Value.Equals(row))
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Check grid for empty cells. 
        /// Recoloring empty cells to another color.
        /// </summary>
        /// <returns>False if there are empty grids.</returns>
        public bool isValidDataEntered(DataGridView grid)
        {
            bool result = true;
            grid.AllowUserToAddRows = false;

            foreach (DataGridViewRow rw in grid.Rows)
            {
                for (int i = 1; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        rw.Cells[i].Style.BackColor = System.Drawing.Color.LightPink;
                        result = false;
                    }
                }
            }
            grid.AllowUserToAddRows = true;
            return result;
        }
        
        /// <summary>
        /// Adding all rows from workingGrid to database.
        /// </summary>
        /// <param name="tableName">Table, where rows will be added.</param>
        /// <param name="grid">Grid - source of rows.</param>
        /// <returns>Number of affected rows.</returns>
        public int addRows(string tableName, DataGridView grid)
        {
            int affectedRows = 0;
            switch (tableName)
            {
                case "Groups":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        uOW.GroupRep.InsertGroup(new Group() { Name = grid.Rows[i].Cells[1].Value.ToString() });
                    }
                    affectedRows = uOW.GroupRep.Save();
                    break;

                case "Students":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        uOW.StudentRep.InsertStudent(new Student() {
                            FirstName = grid.Rows[i].Cells[1].Value.ToString(),
                            LastName = grid.Rows[i].Cells[2].Value.ToString(),
                            Age = int.Parse(grid.Rows[i].Cells[3].Value.ToString()),
                            GroupId = GetIdFromString(grid.Rows[i].Cells[4].Value.ToString())
                                });
                    }
                    affectedRows = uOW.StudentRep.Save();
                    break;

                case "Subjects":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        uOW.SubjectRep.InsertSubject(new Subject() { Name = grid.Rows[i].Cells[1].Value.ToString() });
                    }
                    affectedRows = uOW.SubjectRep.Save();
                    break;

                case "GroupToSubject":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        uOW.GtsRep.InsertGroupToSubject(new GroupToSubject() {
                            GroupId = GetIdFromString(grid.Rows[i].Cells[1].Value.ToString()),
                            SubjectId = GetIdFromString(grid.Rows[i].Cells[2].Value.ToString())
                                });
                    }
                    affectedRows = uOW.GtsRep.Save();
                    break;
                default:
                    break;
            }
            return affectedRows;
        }
        
        /// <summary>
        /// Delete row from table.
        /// </summary>
        /// <param name="tableName">Table, where row will be deleted.</param>
        /// <param name="rId">Id of row you want to delete</param>
        /// <returns></returns>
        public int deleteRow(string tableName, int rId, int secondId = 0)
        {
            switch (tableName)
            {
                case "Groups":
                    uOW.GroupRep.DeleteGroup(rId);
                    return uOW.GroupRep.Save();
                case "Students":
                    uOW.StudentRep.DeleteStudent(rId);
                    return uOW.StudentRep.Save();;
                case "Subjects":
                    uOW.SubjectRep.DeleteSubject(rId);
                    return uOW.SubjectRep.Save();
                case "GroupToSubject":
                    uOW.GtsRep.DeleteGroupToSubject(rId, secondId);
                    return uOW.GtsRep.Save();
                default:
                    break;
            }
            return -1;
        }
        
        /// <summary>
        /// Update rows in database.
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        public int updateRows(string tableName, DataGridView grid) 
        {
            int affectedRows = 0;
            switch (tableName)
            {
                case "Groups":
                    using (var context = new UnitOfWork().GroupRep)
                    {
                        for (int i = 0; i < grid.RowCount - 1; i++)
                        {
                            context.UpdateGroup(new Group()
                            {
                                Id = int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                Name = grid.Rows[i].Cells[1].Value.ToString()
                            });
                        }
                        affectedRows = context.Save();
                    }
                    break;

                case "Students":
                    using (var context = new UnitOfWork().StudentRep)
                    {
                        for (int i = 0; i < grid.RowCount - 1; i++)
                        {
                            context.UpdateStudent(new Student()
                            {
                                Id = int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                FirstName = grid.Rows[i].Cells[1].Value.ToString(),
                                LastName = grid.Rows[i].Cells[2].Value.ToString(),
                                Age = int.Parse(grid.Rows[i].Cells[3].Value.ToString()),
                                GroupId = GetIdFromString(grid.Rows[i].Cells[4].Value.ToString())
                            });
                        }
                        affectedRows = context.Save(); 
                    }
                    break;

                case "Subjects":
                    using (var context = new UnitOfWork().SubjectRep)
                    {
                        for (int i = 0; i < grid.RowCount - 1; i++)
                        {
                            context.UpdateSubject(new Subject()
                            {
                                Id = int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                Name = grid.Rows[i].Cells[1].Value.ToString()
                            });
                        }
                        affectedRows = context.Save(); 
                    }
                    break;

                default:
                    break;
            }
            return affectedRows;
        }
        
        /// <summary>
        /// Transform list to DataTable.
        /// </summary>
        /// <typeparam name="T">List type.</typeparam>
        /// <param name="data">List itself.</param>
        /// <returns>DataTable from list</returns>
        private DataTable convertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
