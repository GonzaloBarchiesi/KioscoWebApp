// Search bar logic for redirecting to the search page
const searchBar = document.getElementById('searchBar');
searchBar.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        var search = searchBar.value;
        console.log('Search Value: ' + search);
        url = `https://localhost:7202/Products/Index/?name=` + encodeURIComponent(search);
        document.location.href = url;
    }
});

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

// Fetch product categories and find the corresponding category
const product = document.getElementById('productId');
const productId = product ? parseInt(product.getAttribute('productId'), 10) : null;
const productName = document.querySelector("h1[product-name]");

fetch("https://localhost:7202/productsCategories/GetProductCategories")
    .then(response => response.json())
    .then(data => {
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

// Function to choose random recommendations and update the HTML
function ChooseRandomRecom(url) {
    fetchData(url).then(data => {
        if (!Array.isArray(data) || data.length === 0) {
            console.log('No recommended products found.');
            return;
        }

        const recomProducts = data;
        const numRandoms = 15;
        const toShow = 5;
        let showedProducts = getUniqueRandomProducts(recomProducts, numRandoms);

        if (showedProducts.length === 0) return;

        const container = document.getElementById('recommendationsContainer');
        container.innerHTML = ''; // Clear previous recommendations

        // Create navigation buttons
        let leftButton = createNavigationButton('left');
        let rightButton = createNavigationButton('right');

        container.appendChild(leftButton); // Add left navigation button

        // Display recommended products
        showedProducts.forEach((product, index) => {
            let productContainer = createProductContainer(product, index, toShow);
            container.appendChild(productContainer);
        });

        container.appendChild(rightButton); // Add right navigation button

        // Attach event listeners to the navigation buttons
        rightButton.onclick = () => slideRight();
        leftButton.onclick = () => slideLeft();
    })
        .catch(error => console.error('Error in ChooseRandomRecom:', error));
}

// Function to generate unique random products
function getUniqueRandomProducts(recomProducts, numRandoms) {
    let uniqueProducts = new Set();

    while (uniqueProducts.size < numRandoms) {
        let randomIndex = Math.floor(Math.random() * recomProducts.length);
        let product = recomProducts[randomIndex];

        // Avoid duplicate products and the currently viewed product
        if (!uniqueProducts.has(product.productName) && product.productName !== productName.textContent) {
            uniqueProducts.add(product);
        }
    }

    return Array.from(uniqueProducts);
}

// Function to create a navigation button (left/right)
function createNavigationButton(direction) {
    let button = document.createElement('i');
    button.classList.add('material-symbols-outlined', 'nav-button');
    button.id = `button-${direction}`;
    button.textContent = direction === 'left' ? 'chevron_left' : 'chevron_right'; // Add icon
    return button;
}

// Function to create a product container and populate its content
function createProductContainer(product, index, toShow) {
    let productContainer = document.createElement('div');
    let linkP = document.createElement('a');
    let img = document.createElement('img');
    let nameP = document.createElement('p');
    let priceP = document.createElement('p');

    // Assign attributes and styles
    linkP.href = `https://localhost:7202/Products/Details/?id=${product.productId}`;
    img.src = `/assets/productos/${product.productName}.png`;
    img.style.width = '200px';
    img.style.height = 'auto';
    nameP.textContent = product.productName;
    priceP.textContent = `${product.price}`;

    // Add classes based on whether the product is initially visible or hidden
    if (index >= toShow) {
        productContainer.classList.add('product-hidden-container');
        linkP.classList.add('product-hidden-link');
        img.classList.add('product-hidden');
        nameP.classList.add('product-hidden');
        priceP.classList.add('product-hidden');
        $(productContainer).hide();  // Hide the product container
    } else {
        productContainer.classList.add('product-item-container');
        linkP.classList.add('product-item-link');
        img.classList.add('product-item');
        nameP.classList.add('product-item');
        priceP.classList.add('product-item');
    }

    // Append elements to the container
    linkP.appendChild(img);
    linkP.appendChild(nameP);
    linkP.appendChild(priceP);
    productContainer.appendChild(linkP);

    return productContainer;
}

// Slide functions
let displayedProducts = Array.from(document.getElementsByClassName('product-item'));
let hiddenProducts = Array.from(document.getElementsByClassName('product-hidden'));

for (var i = 0; i < length; i++) {
    hiddenProducts.push(iCollectionHiddenP[i])
    displayedProducts.push(iCollectionDisplayedP[i])
}
console.log(displayedProducts);
console.log(hiddenProducts);
function slideLeft() {
    console.log(hiddenProducts.innerHTML)
    if (hiddenProducts.length > 0) {
        // Move the last displayed product to hidden and bring the first hidden product to displayed
        let productToHide = displayedProducts.pop(); // Remove the last displayed product
        hiddenProducts.unshift(productToHide); // Add it to the start of hidden products

        let productToShow = hiddenProducts.shift(); // Get the first hidden product
        if (productToShow) {
            displayedProducts.unshift(productToShow); // Add it to the start of displayed products
            const container = document.getElementById('recommendationsContainer');
            let productContainer = createProductContainer(productToShow);
            container.insertBefore(productContainer, container.firstChild); // Insert at the beginning
        }
    }
}

function slideRight() {
    if (displayedProducts.length > 0) {
        // Move the first displayed product to hidden and bring the first hidden product to displayed
        let productToHide = displayedProducts.shift(); // Remove the first displayed product
        hiddenProducts.push(productToHide); // Add it to the end of hidden products

        let productToShow = hiddenProducts.pop(); // Get the last hidden product
        if (productToShow) {
            displayedProducts.push(productToShow); // Add it to the end of displayed products
            const container = document.getElementById('recommendationsContainer');
            let productContainer = createProductContainer(productToShow);
            container.appendChild(productContainer); // Append at the end
        }
    }
}