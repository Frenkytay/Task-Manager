let x = document.cookie;
let cookies = [];
let idx ;
let userIsID = "";
if(x != ""){

    cookies = x.split(";");
    userIsID = cookies[0].split("=")[1];
    userName = cookies[1].split("=")[1];
}


if(userIsID != "" && userIsID != undefined){
    getCategory();
    console.log("KK")
 }else {
     
     console.log(cookies , "SS");
 }
async function getCategory(){
   
    const api_URL = `https://localhost:7296/api/category/user/${userIsID}`
    const response = await fetch( api_URL, {
        method: "GET",
        headers: {
          Accept: "application/json",
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json;charset=utf-8",
        },
      });
      const result = await response.json();
      console.log(result.data);
      const no = 1 ;
      const items = result.data;
      if(items.length <= 0 ){
        return;
      }
     
      console.log("SS");
      for(let i = 0 ; i < items.length; i++){

          $("table").append(`<tr>
          <td>${i+1}</td>
          <td>${result.data[i].category}</td>
          <td><button  class="edit-button" onclick="popUpModalEdit(${items[i].categoryID})" id="edit-category">Edit</button><button  id="delete-category" onclick="popUpModalDelete(${items[i].categoryID})"  class="delete-button">Delete</button></td>
          </tr>`)
    }


}

function popUpModalEdit(i){
    let showbox = document.getElementsByClassName("modal-container");
    showbox[0].classList.remove("display-none");
    document.getElementById("edit-category-button").addEventListener("click",async ()=>{
     
      
            let editText = document.getElementById("edit-category-text").value;
            const data = {
               
                category: editText
            }
            const response = await fetch(`https://localhost:7296/api/Category/${i}`, {
                method: "PUT",
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
            window.location.replace("/category.html");
            

    })


}
function popUpModalDelete(i){
    let showbox = document.getElementsByClassName("modal-container");
    showbox[2].classList.remove("display-none");
    document.getElementById("delete-category-button").addEventListener("click",async ()=>{
       
        
            const response = await fetch(`https://localhost:7296/api/Category/${i}`, {
                method: "DELETE",
                headers: {
                Accept: "application/json",
                "Access-Control-Allow-Origin": "*",
                "Content-Type": "application/json;charset=utf-8",
                },
             
            });
            const result = await response.json();

            if(result.statusCode != 200 ){
                alert(result.massage);
                console.log(result.massage)
                return result.massage;
            }

          
            window.location.replace("/category.html");

    })


}
document.getElementById("add-category").addEventListener("click", ()=>{
    let showbox = document.getElementsByClassName("modal-container");
    showbox[1].classList.remove("display-none");


})

function closePopUp(i){

    let showbox = document.getElementsByClassName("modal-container");
    showbox[i-1].classList.add("display-none");
    console.log(showbox[i].classList)

}
async function addCategory(){
    
    let userID = userIsID;
    let category = document.getElementById("add-category-text").value;
    const data = {
        userID : userID,
        category: category
    }
    const response = await fetch("https://localhost:7296/api/Category", {
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

      window.location.replace("/category.html");



}





