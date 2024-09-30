const searchBar = document.getElementById('searchBar');
const query = document.getElementById('searchBar').value;
const productLinks = Array.from(document.getElementsByClassName('producto-link'));
function showElements() {
    var query = document.getElementById('searchBar').value.toLowerCase(); // Get the search query
    productLinks.forEach(link => {
        var productName = $(link).find('.nombre-producto').text().toLowerCase();
        if (productName.includes(query)) {
            $(link).show() // Show the product if it matches
            $(link).addClass('producto-link')
            $(link).removeClass('producto-hidden-link')
            link.querySelectorAll('.producto').forEach(productos => {
                Array.from(productos).forEach(producto => {
                    producto.show();
                    producto.removeClass('product-hidden')
                    producto.addClass('producto')
                });
            });
            
        } else {
            $(link).hide() // Hide the product if it doesn't match
            $(link).addClass('producto-hidden-link')
            $(link).removeClass('producto-link')
            link.querySelectorAll('.producto').forEach(productos => {
                Array.from(productos).forEach(producto => {
                    producto.show();
                    producto.removeClass('producto')
                    producto.addClass('product-hidden')
                })
               
            });
          

        }
    });

}
window.onload = function () {
    const url = document.location.href;
    params = url.split('?')[1].split('&');
    let data = {};
    let tmp;
    for (var i = 0, l = params.length; i < l; i++) {
        tmp = params[i].split('=');
        data[decodeURIComponent(tmp[0])] = decodeURIComponent(tmp[1]);
    }
    if (url.includes('?name')) {
        searchBar.value = data.name;
        showElements();
    }
       
    else if (data.categoryId) {
        let url = `https://localhost:7202/categories/getProductByCategory/?categoryId=${data.categoryId}`;
        fetchData(url)
    }

    }
let fetchData = function (fetchUrl) { // Iniciacion de la funcion fetchData para aplicarla a los botones
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


    // Search bar functionality

    searchBar.addEventListener('keypress', function (e) {
        showElements();
        
    });
//barra de navegacion - opcion ENTER

const gridProducto = document.getElementById('grid-producto');
const allProductLinks = Array.from(document.getElementsByClassName('producto-link'));
const allProducts = Array.from(document.getElementsByClassName('producto'));
console.log(allProducts);
searchBar.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
            console.log("YOU HAVE ENTERED ENTER :D!")
        let allProducts = Array.from(document.getElementsByClassName('producto'));
        if (allProducts.classList === 'producto-hidden') {
            console.log("There are not products left..");
            // intentando lograr crear contenido en el caso de que no aparezcan ningun producto, para que no quede el fondo vacio.
            // por ahora no funciona bien el condicional...

            noProducts = document.createElement('h2');
            noProducts.classList.add('no-products');
            noProducts.textContent = " Sorry, theres nothing related to your search!";
            gridProducto.appendChild(noProducts);
        }
                
                
                
                    
                
            
        }

});     

searchBar.addEventListener('keydown', function (a) {
    if (a.key === "Backspace" || a.key === "Delete" || a.ctrlKey  && a.keyCode == 90) {
        showElements();
    }

});


const formGo = document.getElementById('opinions');
formGo.addEventListener("click", function (f) {
    window.location.href = '/Form/Opiniones';

});

function ShowItems() {
    allProducts.forEach(product => {
        $(product).show();
    });
    allProductLinks.forEach(link => {
        $(link).show();
    });
}




