$("#LoginForm").submit(function(event){
    var kullaniciEmail=$("#Email").val();
    var kullaniciPassword=$("#Password").val();
    var Data={
        Email:kullaniciEmail,
        Password:kullaniciPassword,
    };


    $.ajax({
        url:'https://localhost:5026/api/auth',
        method:"POST",
        crossDomain:true,
        dataType:"json",
        headers:{
            'Content-Type':'application/json'
        },
        data:JSON.stringify(Data),
        success: function(result){
            alert(result)
        }
        
    })
})
