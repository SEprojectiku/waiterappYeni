$(document).ready(function () {
    var i = 1;
    $("#add_row").click(function () {
        $('#addr' + i).html("<td>" + (i + 1) + "</td><td><select class='form-control' name='select_" + i + "' id='select_" + i + "'></select> </td><td><input  name='name" + i + "' type='text' placeholder='Name'  class='form-control input-md'></td><td><input  name='price" + i + "' type='text' placeholder='Price'  class='form-control input-md'></td><td><input  name='indgr" + i + "' type='text' placeholder='Indegredients'  class='form-control input-md'></td><td><input  name='pretime" + i + "' type='text' placeholder='Prepairing_Time'  class='form-control input-md'></td>");
        $("#DropDownList0 option").each(function (k, v) {
            $('#select_' + i).append('<option value="' + $(v).val() + '">' + $(v).text() + '</option>')
        });

        $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
        i++;
    });
    $("#delete_row").click(function () {
        if (i > 1) {
            $("#addr" + (i - 1)).html('');
            i--;
        }
    });

});
