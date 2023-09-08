let vehicles=[];
function calculateToll(){
   const regNumber = document.getElementById("regNumber").value;
   const Category = document.getElementById("category").value;
   let toll=0;
   if(Category === "bikes"){
       toll=100;
   } else if(Category ==="hmv"){
       toll=200;
   }
   else if(Category ==="lmv"){
       toll=300;
   }
   else if(Category ==="heavyTrucks"){
       toll=500;
   }
vehicles.push({registrationNumber:regNumber,category:Category,toll:toll})
alert('Toll Amount :'+ toll)
}

/*FunctionforStatistics*/
function updateStatistics(){
   const statisticsList = document.getElementById("statistics");
   statisticsList.innerHTML="";
   const categories = ["bikes","hmv","lmv","heavytrucks"];
   categories.vehicle.forEach(category => {
    const totalAmount=vehicles.reduce((acc,vehicle)=> {
        return vehicle.category === category ? acc + vehicle.toll : acc;
   },0);
   
       const listItem = document.createElement("li");
       listItem.textContent= '${category}:$${totalAmount}';
       statisticsList.appendChild(listItem);
   })
}

//filtervehicles
function filterVehicles(){
   const categoryFilter = document.getElementById("searchRegNumber").value.toLowerCase();
   const filteredVehicles=vehicles.filter(vehicle=>{
       return(!categoryFilter || vehicle.category === categoryFilter) && (!regNumberFilter || vehicle.registrationNumber.toLowerCase.includes(regNumberFilter));
   });
   const filteredlist=document.getElementById("filteredVehicles");
   filteredlist.innerHTML="";
   filteredVehicles.forEach(vehicle => {
       const listItem= document.createElement("li");
       listItem.textContent='Reg Number : ${vehicle.registrationNumber}, Category : ${vehicle.category}, Toll:$${vehicle.toll}';
       fillteredlist.appendChild(listItem);
   });
}