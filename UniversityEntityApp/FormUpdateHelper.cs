﻿using System;
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
        private UniversityContext context;

        public FormUpdateHelper() 
        {
            context = new UniversityContext();
        }

        public DataTable ShowTable(string tableName)
        {
            DataTable result = new DataTable();
            var list = new GroupRepository(context).GetGroups().ToList();
            return convertToDatatable<Group>(list);
            /*switch (tableName)
            {
                case "Groups":
                    var list = new GroupRepository(context).GetGroups().ToList();
                    return convertToDatatable<Group>(list);
                case "Subjects":
                    break;
                case "Students":
                    break;
                case "GroupToSubject":
                    break;
                default:
                    break;
            }*/
        }

        /*
        /// <summary>
        /// Create a DataGridViewComboBoxColumn with items of table.
        /// </summary>
        /// <param name="tableName">Table name you want to get values. Can be only Subject or Student table. </param>
        /// <returns>DataGridViewComboBoxColumn with items formatted (<id>,<name>).</returns>
        public DataGridViewComboBoxColumn getRelationComboBox(string tableName)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            if (tableName == "Groups" || tableName == "Subjects")
            {
                cmb.HeaderText = "Select " + tableName;

                DataTable dt = da.GetIdNameVals(tableName);

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
        */
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
        /*
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
                        affectedRows += da.AddGroup( grid.Rows[i].Cells[1].Value.ToString() );
                    }
                    break;
                case "Students":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.AddStudent(grid.Rows[i].Cells[1].Value.ToString(),
                                        grid.Rows[i].Cells[2].Value.ToString(),
                                        int.Parse(grid.Rows[i].Cells[3].Value.ToString()),
                                        GetIdFromString(grid.Rows[i].Cells[4].Value.ToString()));
                    }
                    break;
                case "Subjects":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.AddSubject(grid.Rows[i].Cells[1].Value.ToString());
                    }
                    break;
                case "GroupToSubject":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.AddGroupToSubject(
                                GetIdFromString(grid.Rows[i].Cells[1].Value.ToString()),
                                GetIdFromString(grid.Rows[i].Cells[2].Value.ToString()));
                    }
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
        public int deleteRow(string tableName, int rId)
        {
            switch (tableName)
            {
                case "Groups":
                    return da.DeleteGroupRecord(rId);
                case "Students":
                    return da.DeleteStudentRecord(rId);
                case "Subjects":
                    return da.DeleteSubjectRecord(rId);
                case "GroupToSubject":
                    return da.DeleteGroupToSubj(rId);
                default:
                    break;
            }
            return -1;
        }
        
        /// <summary>
        /// TODOs
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        public int updateRows(string tableName, DataGridView grid) 
        {
            int affectedRows = 0;
            switch (tableName)
            {
                case "Groups":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.UpdateGroupRecord(
                                int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                grid.Rows[i].Cells[1].Value.ToString());
                    }
                    break;
                case "Students":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.UpdateStudentRecord(
                                int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                grid.Rows[i].Cells[1].Value.ToString(),
                                grid.Rows[i].Cells[2].Value.ToString(),
                                int.Parse(grid.Rows[i].Cells[3].Value.ToString()),
                                GetIdFromString(grid.Rows[i].Cells[4].Value.ToString()));
                    }
                    break;
                case "Subjects":
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        affectedRows += da.UpdateSubjectRecord(
                                int.Parse(grid.Rows[i].Cells[0].Value.ToString()),
                                grid.Rows[i].Cells[1].Value.ToString());
                    }
                    break;
                default:
                    break;
            }
            return affectedRows;
        }
        */
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
