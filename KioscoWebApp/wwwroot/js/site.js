
//$(document).ready(function () {
//    $('.details-button').on('click', function () {
//        var productId = $(this).data('product-id');

//        $.ajax({
//            url: '/Products/Details/?id=' + productId,
//            type: 'GET',
//            success: function (htmlContent) {
//                // Assuming you get back HTML, not JSON
//                $('#product-details-container').html(htmlContent);
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                console.error('Error fetching product details:', textStatus, errorThrown);
//            }
//        });
//    });
//});
$(document).ready(function () {
    $('.details-button').on('click', function () {
        var productId = $(this).data('product-id');
        // Redirect to the details page
        window.location.href = '/Products/Index/';
    });


});

  
  
  
 
