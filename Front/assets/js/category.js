$("#addCategoryForm").submit(function(event){
	event.preventDefault();

	var categoryName = $("#Name").val();
	var categoryDescription = $("#Description").val();

	var categoryData = {
		Name: categoryName,
		Description: categoryDescription
	};

	$.ajax({
		url: 'http://localhost:5026/api/Category',
		method: "POST",
		crossDomain: true,
		dataType: "json",
		headers: {
			'Content-Type': 'application/json'
		},
		data: JSON.stringify(categoryData),
		success: function(result){
			alert(result);
		},
		error: function(result){
			alert(result.responseText);
		}
	});
});


$("#deleteCategoryForm").submit(function(event){
	event.preventDefault();
	var categoryId = $("#deleteCategoryId").val();

	$.ajax({
		url: 'http://localhost:5026/api/Category/' + categoryId,
		method: "DELETE",
		headers: {
			'Content-Type': 'application/json'
		},
		success: function(result){
			alert(result);
		},
		error: function(result){
			alert(result.responseText);
		}
	});
});


$("#updateCategoryForm").submit(function(event){
	event.preventDefault();

	var categoryId = $("#updateCategoryId").val();
	var categoryName = $("#updateCategoryName").val();
	var categoryDescription = $("#updateCategoryDescription").val();
	var categoryStatus = $("#updateCategoryStatus").is(":checked");

	var categoryData = {
		Id: categoryId,
		Name: categoryName,
		Description: categoryDescription,
		Status: categoryStatus
	};

	$.ajax({
		url: 'http://localhost:5026/api/Category/' + categoryId,
		method: "PUT",
		contentType: "application/json",
		data: JSON.stringify(categoryData),
		success: function(result){
			alert("Category updated successfully!");
		},
		error: function(result){
			alert("Error: " + result.responseText);
		}
	});
});


