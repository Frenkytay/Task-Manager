let x1 = document.cookie;
let cookies1 = [];

let userIsID1 = "";
let userName1 = "";
if(x1 != ""){

    cookies1 = x1.split(";");
    userIsID1 = cookies1[0].split("=")[1];
    userName1 = cookies1[1].split("=")[1];
}
if(userName1 != "" && userName1 != undefined){
   
    $("#login-text").html(`
    <p>Welcome ${userName1}</p>
    
    
    `)
    $("#userLogin").html(`
    <div id="username-container">
    <div id="username" onclick="showLogoutButton()">
        <div class="User">
            <p>${userName1}</p>
            <img src="images/caret-down-solid.svg" alt="">
        </div>
        
        <div class="logout-button show" id="logout-ID" onclick="logoutUserAcc()">
        Logout
    </div>
    </div>


    
</div>
    
    
    `)
}
function showLogoutButton(){
    console.log("SS")
    document.getElementById("logout-ID").classList.toggle('show');
}

function logoutUserAcc(){
    document.cookie = "customerName=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie ="userID=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.replace("/login.html");
}
function checkUserIsLogin(){
    if(userName1 == "" || userName1 == undefined){
        console.log("FFF");
        window.alert("Login first");
        window.location.replace("/login.html");
    }else {
        window.location.replace("/category.html")
    }
    console.log("FFF");
}


