const searchBar = document.getElementById('searchBar');
// Fetch product categories and find the corresponding category
fetch("https://localhost:7202/productsCategories/GetProductCategories")
    .then(response => response.json())
    .then(data => {
        // Assuming `data` is an array of objects with productId and categoryId
        const productId = parseInt(document.getElementById('productId').getAttribute('productId'), 10);
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
            console.log(url);
            ChooseRandomRecom(url);
        } else {
            console.log("No category found for the given productId.");
        }
    })
    .catch(error => console.error('Error fetching product categories:', error));

// Function to fetch data from a given URL
function fetchData(url) {
    return fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })

        .catch(error => {
            console.error('Error in fetchData:', error);
            throw error; // Re-throw error for further handling
        });
}

// Function to choose random recommendations and update the HTML
function ChooseRandomRecom(url) {
    fetchData(url).then(data => {
        let showedProducts = [];
        const recomProducts = data;

        if (!Array.isArray(recomProducts) || recomProducts.length === 0) {
            console.log('No recommended products found.');
            return;
        }

        for (let i = 0; i < 15; i++) {
            let randIndex = Math.floor(Math.random() * recomProducts.length);                     
            showedProducts.push(recomProducts[randIndex]);
            
        }

        console.log("Random recommended products:", showedProducts);
        console.log("All recomProducts: ", recomProducts);
        const container = document.getElementById('recommendationsContainer');
        container.innerHTML = ''; // Clear previous content

        let leftButton = document.createElement('i');
        leftButton.classList.add('material-symbols-outlined');
        leftButton.id = ('button-left');
        leftButton.Onclick = 'slideLeft';
        container.appendChild(leftButton);

      
        showedProducts.forEach(product => {
            if (showedProducts[product] > 5) {
                let ProductContainer = document.createElement('div') // Intentando distinguir entre productos que se muestran y que no 
                productContainer.classList.add('product-hidden');   // Para poder esconder los que no y asi poder realizar la funcion
                container.appendChild(productContainer);            //slide Right/Left escondiendo y mostrando los productos necesarios
            }
            else { 
            let productContainer = document.createElement('div');
            productContainer.classList.add('product-item');
            container.appendChild(productContainer);

            let linkP = document.createElement(`a`);
            linkP.href = `https://localhost:7202/Products/Details/?id=${product.productId}`;
            linkP.classList = "product-item";
            productContainer.appendChild(linkP);

            let img = document.createElement('img');
            let pImgSrc = `/assets/productos/${product.productName}.png`;
            img.src = pImgSrc;
            img.style.width = '200px';
            img.style.height = 'auto';
            img.classList = "product-item";
            linkP.appendChild(img);

            let nameP = document.createElement('p');
            nameP.textContent = `${product.productName}`;
            nameP.classList = "product-item";
            linkP.appendChild(nameP);

            let priceP = document.createElement('p');
            priceP.textContent = `${product.price}`;
            priceP.classList = "product-item";
            linkP.appendChild(priceP);
            }
        });
        let rightButton = document.createElement('i');
        rightButton.classList = ('material-symbols-outlined');
        rightButton.id = ('button-right');
        rightButton.Onclick = 'slideRight';
        container.appendChild(rightButton);

    })
        .catch(error => console.error('Error in ChooseRandomRecom:', error));
}

// Ensure the productId is correctly initialized
const product = document.getElementById('productId');
const productId = product ? parseInt(product.getAttribute('productId'), 10) : null;

const closeButton = $(`.details-button`);
function closePage() {
    window.location.href = '/Products/Index/';
}
function slideLeft() {

}
function slideRight() {

}
//Pasar el valor de la searchBar a la pagina principal para poder buscar con el mismo valor
searchBar.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        var search = searchBar.value;
        console.log('Search Value: ' + search);
        url = `https://localhost:7202/Products/Index/?name=` + encodeURIComponent(search);
        document.location.href = url;
    }
   
    

});