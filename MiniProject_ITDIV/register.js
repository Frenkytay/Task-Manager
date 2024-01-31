
async function registerUser(){
    
    // console.log("SSS")
    var email = document.getElementById("email");
    var username = document.getElementById("username");
    var password = document.getElementById("password");
    var confirmPass = document.getElementById("confirm-password");
    const cb = document.querySelector('#accept');
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var capital = /[A-Z]/;
    if(email.value == "" ){
      // console.log(email.classList)
      email.classList.add("warning-text");
      $('#email-warning').html("Email Must Filled!");
      setTimeout(()=>{
        email.classList.remove("warning-text");
        $('#email-warning').html("");

      }, 5000);
      // window.alert("Email Required"); 
      return;
    }
    if(!(email.value).match(validRegex)){
      email.classList.add("warning-text");
      $('#email-warning').html("Incorrect Email Format!");
      setTimeout(()=>{
        email.classList.remove("warning-text");
        $('#email-warning').html("");
      }, 5000);
      return;
    }
    if(username.value == ""){
      username.classList.add("warning-text");
      $('#username-warning').html("Username Must Filled!");
      setTimeout(()=>{
        username.classList.remove("warning-text");
        $('#username-warning').html("");
      }, 5000);
      // window.alert("Username Required");
      return
    }
    if(password.value.length < 8){
      password.classList.add("warning-text");
      $('#password-warning').html("Password Length Must 8 Characters Or More!");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#password-warning').html("");
      }, 5000);
      return
      // window.alert("Username Required");
    }
    if(!(password.value).match(capital)){
      console.log("PASSS")
      password.classList.add("warning-text");
      $('#password-warning').html("Password Must Containt Capital");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#password-warning').html("");
      }, 5000);
      return
      // window.alert("Username Required");
    }
    var Symbol = /[!"#$%&'()*+,-.:;<=>?@[\]^_`{|}~]/;
    if(!(password.value).match(Symbol)){
      password.classList.add("warning-text");
      $('#password-warning').html("Password Must Containt Symbol");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#password-warning').html("");
      }, 5000);
      return
    }
    var number = /\d/;
    if(!(password.value).match(number)){
      password.classList.add("warning-text");
      $('#password-warning').html("Password Must Containt Number");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#password-warning').html("");
      }, 5000);
      return
    }
   
    if(password.value != confirmPass.value){
      confirmPass.classList.add("warning-text");
      $('#confirm-password-warning').html("Password Not Match!");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#confirm-password-warning').html("");
      }, 5000);
        
        return;
    }
    if(cb.checked == false ){
      window.alert("Please check the checkbox to proceed!");
      return;
    }
    const data = {
        userName : username.value.trim(),
        userEmail: email.value.trim(),
        userPassword : password.value.trim(),
        userConfirmPassword : confirmPass.value.trim()
        
    }
    console.log(data);
    const response = await fetch("https://localhost:7296/Register", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json;charset=utf-8",
        },
        body : JSON.stringify(data)
      });
      const result = await response.json();

      if(result.statusCode != 201 ){
        alert(result.massage);
        console.log(result.massage)
        return result.massage;
      }
      window.alert("Account Created!");
      const page = window.open("/login.html");
    //   document.cookie = `userID=${result.data[0].userID}`;
      

    //   page.addEventListener("DOMContentLoaded", ()=>{
    //     page.document.getElementById
    //   })
}