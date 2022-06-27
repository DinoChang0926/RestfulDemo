$(document).ready(function () {
	let host = window.location.protocol + "//" + window.location.host;
	$.ajax({
		url: host +"/Api/Member/List",
		type: "get",
		async: false,
		success: function (obj) {		
			$.each(obj, function (index, obj) {
				var newRowContent = "<tr>";
				newRowContent += "<td>" + obj.id + "</td>";
				newRowContent += "<td>";
				newRowContent += "<a href='"+ host + "/Home/Edit?Id=" + obj.id +"'>" + obj.name + "</a>";; newRowContent += "";
				newRowContent += "</td>";
				newRowContent += "<td>" + obj.email +"</td>";
				newRowContent += "<td>" +obj.skills+"</td>";
				newRowContent += "<td>" +obj.reportTo+"</td>";
				newRowContent += "<td>" +obj.createTime+"</td>";
				newRowContent += "<td>" +obj.editor+"</td>";
				newRowContent += "<td>" +obj.editTime+"</td>";
				$(newRowContent).appendTo($("#MemberTable"));
			});

	
		},
		error: function () {
			console.log("Error");
		}
	});
});

