$(document).ready(function () {
    $("#create-student").click(function () {
        //console.log($("#add-student-form").serialize());

        $.ajax({
            type: 'POST',
            url: '/Students/AjaxAdd',
            //if we want get form as an object by name attribute
            //data: $("#add-student-form").serialize()
            //getting values from each input separately by id
            data: {
                FirstName: $("#FirstName").val(),
                LastName: $("#LastName").val(),
                Age: $("#Age").val(),
                GroupId: $("#GroupId").val(),
            },
            success: function (data) {
                $('#students-table').html(data);
            }
        });
        
        /*.done(function (data) {
            $("#studentsList").empty();
            //using foreach function I've found in internet
            //have no idea how it works
            $.each(data, function (i, item) {
                var tr = $('<tr>').append(
                    $('<td>').text(item.FirstName),
                    $('<td>').text(item.LastName),
                    $('<td>').text(item.Age),
                    $('<td>').text(item.GroupName),
                    $('<td>').html('<a href="/Students/Edit/' + item.Id + '">Edit</a> | ' +
                    '<a href="/Students/Delete/' + item.Id + '">Delete</a>')
                );
                $('#studentsList').append(tr);
            });*/
    });
});