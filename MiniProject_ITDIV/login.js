async function checkLogin(){
    console.log("SSS")
    var email = document.getElementById("email");
    var password = document.getElementById("password");
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if(email.value == "" ){
      email.classList.add("warning-text");
      $('#email-warning').html("Email Must Filled!");
      setTimeout(()=>{
        email.classList.remove("warning-text");
        $('#email-warning').html("");

      }, 5000);
    
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
    if(password.value == ""){
      password.classList.add("warning-text");
      $('#password-warning').html("Username Must Filled!");
      setTimeout(()=>{
        password.classList.remove("warning-text");
        $('#password-warning').html("");
      }, 5000);
      // window.alert("Password Required");
      return;
    }
    const data = {
        userEmail: email.value.trim(),
        userPassword : password.value.trim()
    }
    const response = await fetch("https://localhost:7296/Login", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json;charset=utf-8",
        },
        body : JSON.stringify(data)
      });
      const result = await response.json();
  
      if(result.statusCode != 200 ){
        alert(result.massage);
        console.log(result.massage)
        return result.massage;
      }
      document.cookie = `userID=${result.data[0].userID}`;
      document.cookie = `customerName=${result.data[0].userName}`
 
      window.location.replace("/homepage.html");



}
