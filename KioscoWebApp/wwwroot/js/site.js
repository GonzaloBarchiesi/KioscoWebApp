let fetchData = function(fetchUrl) { // Iniciacion de la funcion fetchData para aplicarla a los botones
    fetch(fetchUrl)
        .then((response) => response.json())
        .then((data) => {

            const fetchedProductIds = data.map(product => product.productId);

            productos.forEach(function (productElement) {
                // Assuming product ID is stored in a data attribute like 'data-product-id'
                const productId = productElement.getAttribute('data-product-id');

                if (fetchedProductIds.includes(parseInt(productId))) {
                    // Show the product (set display to block or flex)
                    productElement.style.display = "block";
                } else {
                    // Hide the product (set display to none)
                    productElement.style.display = "none";
                }
            });

        })
        .error(console.log(error));
}
const productos = document.querySelectorAll('.producto-link');//Funcionalidad de botones

const alfajoresButton = document.getElementById('alfajoresBut')
alfajoresButton.addEventListener("click", function (event) {
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=1";//fetch con la info de alfajores
    fetchData(fetchUrl); 
});

const bebidasButton = document.getElementById('bebidasBut')
bebidasButton.addEventListener("click", function (event) {
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=2";//fetch con la info de bebidas
    fetchData(fetchUrl); 
});

const snacksButton = document.getElementById('snacksBut')
snacksButton.addEventListener("click", function (event) {
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=3"; //...
    fetchData(fetchUrl); 
});

const chiclesButton = document.getElementById('chiclesBut')
chiclesButton.addEventListener("click", function(event){
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=4";//._.
    fetchData(fetchUrl); 
       });
const dulcesButton = document.getElementById('dulcesBut')
dulcesButton.addEventListener("click", function (event) {
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=5";
    fetchData(fetchUrl);
       
});
const galletitasButton = document.getElementById('galletitasBut')
galletitasButton.addEventListener("click", function (event) {
    let fetchUrl = "https://localhost:7202/categories/getProductByCategory/?categoryId=6";
    fetchData(fetchUrl)
   });

document.getElementById('searchBar').addEventListener("input", (e) => {
    let value = e.target.value;
    if (value == " ") {                                   // Otra funcionalidad barra navegacion
        e.target.value = value.replace(/[^A-Z\d-]/g, ""); // se reemplaza por nada el poner un espacio al principio del input de la barra de nav.
    }
});

$(document).ready(function () {
    // Search bar functionality
    const searchBar = document.getElementById('searchBar');
    searchBar.addEventListener('keypress', function (e) {
        var query = document.getElementById('searchBar').value; // Get the search query
        $('.producto-link').each(function () {
            var productName = $(this).find('.nombre-producto').text().toLowerCase();
            if (productName.includes(query)) {
                $(this).show(); // Show the product if it matches
            } else {
                $(this).hide(); // Hide the product if it doesn't match
            }
        });
    });
});

//barra de navegacion - opcion ENTER
$(document).ready(function () {
  
    document.getElementById('searchBar').addEventListener('keypress', function (e) {
        query = document.getElementById('searchBar').value;
        if (e.key === 'Enter') {
            $('.product-link').each(function () {
                var productName = $(this).find('.nombre-producto').text().toLowerCase();
                productName.includes(query) ? $(this).show() : $(this).hide();
                if ($(this).find('.nombre-producto').text() == null) {
                    // intentando lograr crear contenido en el caso de que no aparezcan ningun producto, para que no quede el fondo vacio.
                     // por ahora no funciona bien el condicional...
                }
                
                    
                
            });
        }
});     
});


  
  
 

 



