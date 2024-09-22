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

//Fetchear 
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

        const recomSubtitleDiv = document.createElement('div');
        recomSubtitleDiv.classList.add('recom-products');
        recomSubtitleDiv.id = ('recom-subtitle-div')
        const recomSubtitle = document.createElement('p');
        recomSubtitle.id = ('recom-subtitle');
        recomSubtitle.textContent = "Productos Relacionados";
        recomSubtitle.classList.add('recom-products');
        recomSubtitleDiv.appendChild(recomSubtitle);
        container.appendChild(recomSubtitleDiv);

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
        rightButton.onclick = () => slideRight(container);
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
    let buttonIcon = document.createElement('button');
    buttonIcon.classList.add('icon-button');
    buttonIcon.id = `button-${direction}`;
    let icon = document.createElement('i');
    icon.classList.add('material-symbols-outlined', 'nav-icon');
    icon.id = `icon-${direction}`;
    icon.textContent = direction === 'left' ? 'chevron_left' : 'chevron_right'; // Add icon
    buttonIcon.appendChild(icon);
    return buttonIcon;
}
const closeButton = $(' .details-button');
function closePage() {
    window.location.href = '/Products/Index/';
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
        nameP.classList.add('product-hidden', 'recomendation-name');
        priceP.classList.add('product-hidden');

        $(productContainer).hide();  // Hide the product container
    } else {
        productContainer.classList.add('product-item-container');
        linkP.classList.add('product-item-link', 'product-item');
        img.classList.add('product-item');
        nameP.classList.add('product-item', 'recomendation-name');
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

function slideLeft() {
    let displayedContainers = Array.from(document.getElementsByClassName('product-item-container'));
    let hiddenContainers = Array.from(document.getElementsByClassName('product-hidden-container'));
    const container = document.getElementById('recommendationsContainer');
    let firstChild = displayedContainers[0];
    let lastChild = displayedContainers[displayedContainers.length -1] // Intentando desaparecer el boton de scroll cuando el elemento ultimo/primero de los hiddenContainers sea igual 
    console.log(lastChild)                                             // a el primer/ ultimo de los primeros productos que aparecen (displayedContainers(first & lastChild)
    for (var i = 0; i < 5; i++) {
        if (displayedContainers.length > 0 && hiddenContainers.length > 0) {
            // Move the last displayed container to hidden
            let containerToHide = displayedContainers.pop(); // Remove the last displayed container
            containerToHide.classList.add('product-hidden-container');
            containerToHide.classList.remove('product-item-container');
            containerToHide.querySelectorAll('a').forEach(link => {
                link.classList.remove('product-item-link', 'product-item');
                link.classList.add('product-hidden-link')
            });
            containerToHide.querySelectorAll('img').forEach(subItem => {
                subItem.classList.remove('product-item');
                subItem.classList.add('product-hidden');
            });

            containerToHide.querySelectorAll('p').forEach(subItem => {
                subItem.classList.remove('product-item');
                subItem.classList.add('product-hidden');
            });
            $(containerToHide).hide(); // Hide the entire product container

            // Bring the first hidden container to displayed
            let containerToShow = hiddenContainers.shift(); // Get the first hidden container
            containerToShow.classList.remove('product-hidden-container');
            containerToShow.classList.add('product-item-container');
            containerToShow.querySelectorAll('a').forEach(link => {
                link.classList.remove('product-hidden-link', 'product-hidden');
                link.classList.add('product-item-link', 'product-item')
            });
            containerToShow.querySelectorAll('img').forEach(subItem => {
                subItem.classList.remove('product-hidden');
                subItem.classList.add('product-item');
            });
            containerToShow.querySelectorAll('p').forEach(subItem => {
                subItem.classList.remove('product-hidden');
                subItem.classList.add('product-item');
            });
            $(containerToShow).show(); // Show the entire product container

            // Reinsert the updated containers to maintain the DOM order
          
            container.appendChild(containerToHide); // Add the hidden container to the end
            container.insertBefore(containerToShow, container.firstChild); // Add the displayed container to the beginning
        } else {
            console.log("No more products to slide left!");
        }
    }
 
}

function slideRight() {
    for (var i = 0; i < 5; i++) {
        let displayedContainers = Array.from(document.getElementsByClassName('product-item-container'));
        let hiddenContainers = Array.from(document.getElementsByClassName('product-hidden-container'));

        console.log("Displayed Products: ", displayedContainers);
        console.log("Hidden Products: ", hiddenContainers);

        if (displayedContainers.length > 0 && hiddenContainers.length > 0) {
            // Move the last displayed container to hidden
            let containerToHide = displayedContainers.shift(); // Remove the last displayed container
            containerToHide.classList.add('product-hidden-container');
            containerToHide.classList.remove('product-item-container');
            containerToHide.querySelectorAll('a').forEach(link => {
                link.classList.remove('product-item-link', 'product-item');
                link.classList.add('product-hidden-link', 'product-hidden');
            });
            $(containerToHide).hide(); // Hide the entire product container

            // Bring the first hidden container to displayed
            let containerToShow = hiddenContainers.shift(); // Get the first hidden container
            containerToShow.classList.remove('product-hidden-container');
            containerToShow.classList.add('product-item-container');
            containerToShow.querySelectorAll('a').forEach(link => {
                link.classList.remove('product-hidden-link', 'product-hidden');
                link.classList.add('product-item-link', 'product-item');
            });
            $(containerToShow).show(); // Show the entire product container

            // Reinsert the updated containers to maintain the DOM order
            const container = document.getElementById('recommendationsContainer');
            container.appendChild(containerToHide); // Add the hidden container to the end
            container.appendChild(containerToShow, container.firstChild); // Add the displayed container to the beginning

            console.log("Updated Displayed Products: ", document.getElementsByClassName('product-item-container'));
            console.log("Updated Hidden Products: ", document.getElementsByClassName('product-hidden-container'));
        } else {
            console.log("No more products to slide left!");
        }
    }
    
}

