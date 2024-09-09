const alfajoresButton = document.getElementById('alfajoresBut')
alfajoresButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=1") //fetch con la info de alfajores
    .then((response) => response.json())
    .then((data) => {
        console.Log(data);
    })
    .error(console.Log(error));
});
const bebidasButton = document.getElementById('bebidasBut')
    bebidasButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=2") //fetch con la info de bebidas
        .then((response) => response.json())
        .then((data) => {
            console.Log(data);
        })
        .error(console.Log(error));
});

const snacksButton = document.getElementById('snacksBut')
snacksButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=3")  //...
        .then((response) => response.json())
        .then((data) => {
            console.Log(data);
        })
        .error(console.Log(error));
});

const chiclesButton = document.getElementById('chiclesBut')
chiclesButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=4") //._.
        .then((response) => response.json())
        .then((data) => {
            console.Log(data);
        })
        .error(console.Log(error));
});
const dulcesButton = document.getElementById('dulcesBut')
dulcesButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=5")
        .then((response) => response.json())
        .then((data) => {
            console.Log(data);
        })
        .error(console.Log(error));
});
const galletitasButton = document.getElementById('galletitasBut')
    galletitasButton.addEventListener("keypress", (e) => {
    fetch("https://localhost:7202/categories/getProductByCategory/?categoryId=6")
        .then((response) => response.json())
        .then((data) => {
            console.Log(data);
        })
        .error(console.Log(error));
});



//boton para volver al menu principal
$(document).ready(function () {
    $('.details-button').on('click', function () {
       
        // Redirect to the details page
        window.location.href = '/Products/Index/';
    });


});

document.getElementById('searchBar').addEventListener("input", (e) => {
    let value = e.target.value;
    if (value == " ") {
        e.target.value = value.replace(/[^A-Z\d-]/g, ""); // se reemplaza por nada el poner un espacio al principio del input de la barra de nav.
    }
});

//barra de navegacion - opcion ENTER
$(document).ready(function () {
    // Search bar functionality
    document.getElementById('searchBar').addEventListener('keypress', function (e) {
        query = document.getElementById('searchBar').value;
        if (e.key === 'Enter') {
            $('.product-link').each(function () {
                var productName = $(this).find('.nombre-producto').text().toLowerCase();
                if (productName.includes(query)) {
                    $(this).show(); // Show the product if it matches
                } else {
                    $(this).hide(); // Hide the product if it doesn't match
                }
            });
        }
});     
});


  
  
 

 



