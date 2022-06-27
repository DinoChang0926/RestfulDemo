$(document).ready(function () {
    let host = window.location.protocol + "//" + window.location.host;
    let url = new URL(location.href);
    let Id = url.searchParams.get('Id');
    $.ajax({
        url: host + "/Api/Member/Get?Id=" + Id,
        type: "get",
        async: false,
        success: function (obj) {    
            let areas = obj.area.split(','); 
            let skills = obj.skills.split(',');               
            for (i = 0; i < skills.length; i++) {
                skills[i] = "'" + skills[i] + "'";
            }
            $("input[name='Id']").val(obj.id);
            $("input[name='ShowId']").val(obj.id);
            $("input[name='Name']").val(obj.name);
            $("input:radio[name='Sex']").filter('[value=' + obj.sex + ']').prop('checked', true);
            $("input[name='Email']").val(obj.email);
            $("input[name='CellPhone']").val(obj.cellPhone);
            $("input[name='Phone']").val(obj.phone);             
            $("#Areas").find('[value=' + areas.join('], [value=') + ']').prop("checked", true);
            $("#Skills").find('[value=' + skills.join('], [value=') + ']').prop("checked", true);       
            $("input:radio[name='Status']").filter('[value=' + obj.status + ']').prop('checked', true);
            $("input[name='ReportTo']").val(obj.reportTo);
            $("input[name='CreateTime']").val(obj.createTime);
            $("input[name='Editor']").val(obj.editor);
            $("input[name='EditTime']").val(obj.editTime);  
        },
        error: function () {
            console.log("Error");
        }
    });
});


$("#EditSubmit").click(function () {  
    var EditCheck = confirm('確定修改嗎？');
    if (EditCheck) {
        let host = window.location.protocol + "//" + window.location.host;
        let skill = "", area = "";
        $.each($('input[name=skill]:checked'), function () {
            skill += $(this).val() + ",";
        });
        $.each($('input[name=area]:checked'), function () {
            area += $(this).val() + ",";
        });
        $("input[name='Skills']").val(skill.slice(0, skill.length - 1));
        $("input[name='Area']").val(area.slice(0, area.length - 1));
        var formData = $('#Member').serialize();   
        if (EditCheck) {
            $.ajax({
                url: host + "/Api/Member/Edit",
                type: "POST",
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: formData,
                success: function (result) {
                    console.log(result);
                    if (result = 'Succeed') {
                        alert("更新成功!");

                    }
                },
                error: function (xhr, resp, text) {
                    console.log(xhr, resp, text);
                }
            })
        }
    }    
});



$("#Delete").click(function () {
    var DeleteCheck = confirm('確定刪除嗎？');
    if (DeleteCheck) {
        let host = window.location.protocol + "//" + window.location.host + "/Api/Member/Delete";
        let Id = $("input[name='Id']").val();
        $.ajax({
            url: host,
            type: "post",
            async: false,
            data: {
                'Id': Id
            },
            beforeSend: function (xhr) {
                //for CSRF
                xhr.setRequestHeader("requestverificationtoken",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (result) {
                if (result.item1) {
                    alert(result.item2);
                    window.location.href = "/";
                }
            },
            error: function () {
                console.log("Error.");
            }
        });
    }
});