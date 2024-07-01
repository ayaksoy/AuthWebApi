// getAllCategory();

// function getAllCategory(){
//     $.ajax({
//         url:'https://localhost:7222/api/Category',
//         method:"GET",
//         crossDomain:true,
//         dataType:"json",
//         success: function (data){
//             categoryDisplay(data);
//         }
//     })
// }

// function categoryDisplay(categories){
//     var categoryList=$("#categories");
//     categoryList.empty();

//     $.each(categories, function(index,category){
//         categoryList.append(`
//             <tr>
//                 <td>${category.id}</td>
//                 <td>${category.name}</td>
//                 <td>${category.description}</td>
//                 <td>${category.isStatus}</td>
//                 <td>
//                     <button class="btn btn-danger" onclick="deleteCategory(${category.id})">Delete</button>
//                     <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#categoryDetail_${category.id}">Update</button>
//                     <div class="modal fade" id="categoryDetail_${category.id}">
//                         <div class="modal-dialog">
//                             <div class="modal-content">
//                                 <div class="modal-header">
//                                     <h1 class="modal-title fs-5">${category.name}</h1>
//                                     <button type="button" class="btn-close" data-bs-dismiss="modal" aria_label="Close"></button>
//                                 </div>
//                                 <div class="modal-body">  
                                   
//                                         <table class="table">
//                                             <tr>
//                                                 <th>Id</th>
//                                                 <td>${category.id}</td>
                                                
//                                             </tr>
//                                             <tr>
//                                                 <th>Name</th>
//                                                 <td><input type="text" value="${category.name}" class="form-control" id="updateName_${category.id}"></td>
//                                             </tr>
//                                             <tr>
//                                                 <th>Description</th>
//                                                 <td><input type="text" value="${category.description}" class="form-control" id="updateDescription_${category.id}"></td>
//                                             </tr>
//                                             <tr>
//                                                 <th>
//                                                     Status 
//                                                     <button class="btn btn-${category.isStatus?"success":"danger"} btn-sm">${category.isStatus?"Active":"Passive"}</button>
//                                                 </th>
//                                                 <td>
//                                                     <select class="form-control" id="updateStatus_${category.id}">
//                                                         <option value="true" ${category.isStatus?"selected":""}>Active</option>
//                                                         <option value="false"${category.isStatus?"":"selected"}>Passive</option>
//                                                     </select>

//                                                 </td>
//                                             </tr>
//                                             <tr>
//                                                 <td colspan="2">
//                                                     <button type="button" class="btn btn-success form-control" onclick="updateCategory(${category.id})">Update</button>
//                                                 </td>
//                                             </tr>
//                                         </table>
                                    
//                                 </div>
//                             </div>
//                         </div>
//                     </div>
//                 </td>
//             </tr>
//             `)
//     })
// }

// $("#addCategoryForm").submit(function(event){
//         var categoryName=$("#Name").val();
//     var categoryDescription=$("#Description").val();
//     var categoryStatus=$("#Status");
//     var categoryData={
//         Name:categoryName,
//         Description:categoryDescription,
//         IsStatus:categoryStatus.is(":checked")?true:false
//     };


//     $.ajax({
//         url:'https://localhost:7222/api/Category',
//         method:"POST",
//         crossDomain:true,
//         dataType:"json",
//         headers:{
//             'Content-Type':'application/json'
//         },
//         data:JSON.stringify(categoryData),
//         success: function(result){
//             getAllCategory();
//             alert(result)
//         }
        
//     })
// })

// function deleteCategory(id){
//     $.ajax({
//         url:'https://localhost:7222/api/Category/'+id,
//         method:"DELETE",
//         success:function(data){
//             getAllCategory();
//             alert(data);
//         }
//     })
// }


// function updateCategory(id){

//     var categoryName=$("#updateName_"+id).val();
//     var categoryDescription=$("#updateDescription_"+id).val();
//     var categoryStatus=$("#updateStatus_"+id).val();
//     var categoryData={
//         Id:id,
//         Name:categoryName,
//         Description:categoryDescription,
//         IsStatus:categoryStatus=="true"?true:false
//     };


//     $.ajax({
//         url:'https://localhost:7222/api/Category/'+id,
//         method:"PUT",
//         crossDomain:true,
//         dataType:"json",
//         headers:{
//             'Content-Type':'application/json'
//         },
//         data:JSON.stringify(categoryData),
//         success: function(result){
//             alert(result.responseText)
//         },
//         error: function(result){
//             alert(result.responseText)
//         }
//     })

//      window.location.reload();
// }



$("#loginForm").submit(function(event){
    event.preventDefault();
    var email=$("#Email").val();
    var password=$("#Password").val();
    var loginData={
        Email:email,
        Password:password
    };


$.ajax({
    url:'http://localhost:5026/api/Auth/login',
    method:"POST",
    crossDomain:true,
    dataType:"json",
    headers:{
        'accept': '*/*',
        'Content-Type':'application/json'
    },
    data:JSON.stringify(loginData),
    success: login()
    ,
    error: function(result){
        alert("Giriş Başarısız")
    }
    
})
})


$("#registerForm").submit(function(event){
    event.preventDefault();
    var email=$("#Email").val();
    var password=$("#Password").val();
    var name = $("#Name").val();
    var surname = $("#Surname").val();
    var registerData={
        Email:email,
        Password:password,
        Name : name,
        Surname : surname
    };


$.ajax({
    url:'http://localhost:5026/api/Auth/create',
    method:"POST",
    crossDomain:true,
    dataType:"json",
    headers:{
        'accept': '*/*',
        'Content-Type':'application/json'
    },
    data:JSON.stringify(registerData),
    success: function(ahmet){
        alert(ahmet.message)
    },
    error: function(_resultt){
        alert(_resultt.responseText)
    }
    
})
})

$("#forgotPasswordForm").submit(function(event){
    event.preventDefault();
    var email=$("#Email").val();
    var password=$("#Password").val();
    var newPassword = $("#NewPassword").val();
    var registerData={
        Email:email,
        OldPassword:password,
        NewPassword : newPassword,
    };


$.ajax({
    url:'http://localhost:5026/api/Auth/update',
    method:"PUT",
    crossDomain:true,
    dataType:"json",
    headers:{
        'accept': '*/*',
        'Content-Type':'application/json'
    },
    data:JSON.stringify(registerData),
    success: function(resultt){
        alert(resultt.message)
    },
    error: function(_resultt){
        alert(_resultt.responseText)
    }
    
})
})
function login (){
    window.parent.postMessage('login-success','*');
}



$("#addProductForm").submit(function(event){
    event.preventDefault();
    var email=$("#Email").val();
    var password=$("#Password").val();
    var name = $("#Name").val();
    var surname = $("#Surname").val();
    var registerData={
        Email:email,
        Password:password,
        Name : name,
        Surname : surname
    };


$.ajax({
    url:'http://localhost:5026/api/Auth/create',
    method:"POST",
    crossDomain:true,
    dataType:"json",
    headers:{
        'accept': '*/*',
        'Content-Type':'application/json'
    },
    data:JSON.stringify(registerData),
    success: function(ahmet){
        alert(ahmet.message)
    },
    error: function(_resultt){
        alert(_resultt.responseText)
    }
    
})
})

$("#addCategoryForm").submit(function(event){
        var categoryName=$("#Name").val();
    var categoryDescription=$("#Description").val();
    var categoryData={
        Name:categoryName,
        Description:categoryDescription
    };


    $.ajax({
        url:'http://localhost:5026/api/Category',
        method:"POST",
        crossDomain:true,
        dataType:"json",
        headers:{
            'Content-Type':'application/json'
        },
        data:JSON.stringify(categoryData),
        success: function(result){
            alert(result)
        },
        error: function(result){
            alert(result.responseText)
        }
        
    })
})
