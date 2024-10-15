//funciones principales para display productos recomendados

let productsPerPage; //productos por pagina recomendados\\
let beforeProductsPerPage;
let currentIndex = 0;
let endIndex = 0;
setProductsPerPage(); // <------

function setProductsPerPage() { //ajustar productos per swipe (cada vez que se ajusta la pagina) y cuando inicia
    let windowWidth = window.innerWidth;
    beforeProductsPerPage = productsPerPage;
    if (windowWidth > 1450) {
        productsPerPage = 5;
    } else if (windowWidth >= 1180) {
        productsPerPage = 4;
    } else if (windowWidth >= 830) {
        productsPerPage = 3;
    } else {
        productsPerPage = 2;
    }
    initializeProducts(currentIndex); //inicializar productos en base a este cambio
    return { productsPerPage, beforeProductsPerPage };
}
window.addEventListener("resize", (event) => { //Cada vez que la pagina comete risize se actualizan los productos
        setProductsPerPage();
    
});

const product = document.getElementById('productId');
const productId = product ? parseInt(product.getAttribute('productId'), 10) : null;
let url = "";
async function initializeProducts(index) {
    const fetchedUrl = await fetchCategory();
    if (fetchedUrl) {
        fetchProducts(fetchedUrl, currentIndex); 
    }
}
//FUNCION PARA FETCHEAR LA CATEGORIA DEL PRODUCTO EN CUESTION
async function fetchCategory() {
    try {
        const response = await fetch("https://localhost:7202/productsCategories/GetProductCategories");
        const data = await response.json();
        let recomCategory = null;

        for (const item of data) {
            if (item.productId === productId) {
                recomCategory = item.categoryId;
                console.log("Found category for product:", recomCategory);
                break;
            }
        }

        if (recomCategory) {
            const url = `https://localhost:7202/categories/getProductByCategory/?categoryId=${recomCategory}`;
            return url; // Return the URL here
        } else {
            console.log("No category found for the given productId.");
            return null; // Return null if no category is found
        }
    } catch (error) {
        console.error('Error fetching product categories:', error);
        return null; // Return null in case of an error
    }
}

// DEFINE TODOS LOS PRODUCTOS RELACIONADOS Y SE CREAN LOS BOTONES (fetcheando desde la categoria del producto principal)
 async function fetchProducts(url, index) {
     try {
         const response = await fetch(url); // URL to your JSON file
         if (!response.ok) {
             throw new Error(`HTTP error! status: ${response.status}`);
         }
         let products = await response.json();
       
         const { buttonL, buttonR } = displayProducts(index, products);
         // Event listeners for the navigation buttons
         buttonR.addEventListener("click", () => {
             if (currentIndex + productsPerPage < products.length) {
                 currentIndex += productsPerPage;
                 initializeProducts(currentIndex);
                 //fetchProducts(url, currentIndex);
             }
            
         });
         buttonL.addEventListener("click", () => {
             if (currentIndex >= productsPerPage) {
                 currentIndex -= productsPerPage;
                 initializeProducts(currentIndex);
                 if (currentIndex <= 0) {
                     $(buttonL).hide();
                 }
             }
         });

    } catch (error) {
        console.error("Error fetching products:", error);
    }
}
//SE DISPLAYAN LOS PRODUCTOS SACADOS DESDE UN INDICE DETERMINADO HASTA OTRO INDICE DETERMINADO (start/end index)
function displayProducts(startIndex, products) {
    let displayedProducts = document.getElementsByClassName('product-item-container');
    let productsContainer = document.getElementById("recommendationsContainer");
    productsContainer.innerHTML = ""; // Clear the container
      endIndex = startIndex + productsPerPage;
      if (endIndex % productsPerPage != 0) {
           if (products.length <= endIndex) {
               endIndex = products.length - 1;
               if (displayedProducts != 1 && productsPerPage != displayedProducts + 1) {
                   startIndex = endIndex - productsPerPage;
               }
          }
          
    }
    //Estos ifs son para modificar los indices cada vez que se modifica el tamaño de la pagina y necesita ser cambiado, es un poco entreverado pero bueno



      //CREACION BOTONES
    const buttonL = document.createElement("button");
    buttonL.innerHTML = '<img src="/assets/Arrows/chevron-left.svg" alt="left">';
    buttonL.classList.add("icon-button")
    buttonL.id = "button-left";

    const iconL = document.createElement("i");
    iconL.classList.add("material-symbols-outlined");
    iconL.id = "icon-left";
    buttonL.appendChild(iconL);

    const buttonR = document.createElement("button");
    buttonR.innerHTML = '<img src="/assets/Arrows/chevron-right.svg" alt="left">';
    buttonR.classList.add("icon-button")
    buttonR.id = ("button-right");

    const iconR = document.createElement("i");
    iconR.classList.add("material-symbols-outlined");
    iconR.id = "icon-right";
    buttonR.appendChild(iconR);
    
    productsContainer.appendChild(buttonL);
    productsContainer.appendChild(buttonR);

 //Se limpian posibles productos indefinidos y el mismo producto que el principal
      for (var i = 0; i < products.length; i++) {
          if (products[i] === undefined) {
              break;
          }
          let product = products[i];
          if (productId === product.productId) {
              products.splice(i, 1);
          }
    }
    //Se crea el div de cada producto a traves de los indices cortando todos los productos relacionados
      let productsToShow = products.slice(startIndex, endIndex); 
    Array.from(productsToShow).forEach(product => {

          //CREACION Product-item-containers
          const productDiv = document.createElement("div");
          productDiv.classList.add("product-item-container");

          const linkP = document.createElement("a");
          linkP.href = `/Products/Details/?id=${product.productId}`
          linkP.classList.add('product-item-link');

          const img = document.createElement("img");
          img.src = `/assets/productos/${product.productName}.png`;
          img.alt = product.productName;
          img.classList.add("product-item")

          const name = document.createElement("p");
          name.textContent = product.productName;
          name.classList.add("product-item")

          const price = document.createElement("p");
          price.textContent = `$${product.price}`;
          price.classList.add("product-item")

          //Se appendean cada propiedad de producto con el indice y el mismo con el container
          productDiv.appendChild(linkP);
          linkP.appendChild(img);
          linkP.appendChild(name);
        linkP.appendChild(price);
        // Se appendea cada product-container con el recommendationContainer
          productsContainer.appendChild(productDiv);

      });
      currentIndex = startIndex;
      return { buttonL, buttonR };
      }


// Otras funciones de la pagina---------------------------------------------------------------------------

function closePage() {
    window.location.href = "/Products/Index"
}

// Funciones searchBar
const searchBar = document.getElementById('searchBar');
searchBar.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        var search = searchBar.value;
        console.log('Search Value: ' + search);
        url = "https://localhost:7202/Products/Index/?name=" + encodeURIComponent(search);
        document.location.href = url;
    }
}); 

//FUNCIONES CATEGORYBUTTONS
const alfajoresButton = document.getElementById('alfajoresBut');
const bebidasButton = document.getElementById('bebidasBut');
const snacksButton = document.getElementById('snacksBut');
const chiclesButton = document.getElementById('chiclesBut');
const dulcesButton = document.getElementById('dulcesBut');
const galletitasButton = document.getElementById('galletitasBut');

const opinionesButton = document.getElementById('opiniones');
opinionesButton.addEventListener("click", function (event) {
    window.location.href = '/Form/Opiniones';
});
function GetCategory(catId) {
    let categoryId = catId;
    window.location.href = `/Products/Index/?categoryId =${categoryId}`;
}
alfajoresButton.addEventListener('click', function () {
    let catId = 1;
    S(catId);
});

bebidasButton.addEventListener('click', function () {
    let catId = 2;
    GetCategory(catId);
});

snacksButton.addEventListener('click', function () {
    let catId = 3;
    GetCategory(catId);
});

chiclesButton.addEventListener('click', function () {
    let catId = 4;
    GetCategory(catId);
});
dulcesButton.addEventListener("click", function () {
    let catId = 5;
    GetCategory(catId)

});

galletitasButton.addEventListener('click', function () {
    let catId = 6;
    GetCategory(catId);
});