$('.getRow').click(function (e) {
    e.preventDefault();
    $('.lineId').val(($(this).attr('getLineId')));
    $('.reqId').val(($(this).attr('getReqId')));
    $('.productId').val(($(this).attr('getProductId')));
    $('.line').val(($(this).attr('getLine')));
    $('.quantity').val(($(this).attr('getQuantity')));
    $('.salePrice').val(($(this).attr('getSalePrice')));
    $('.description').val(($(this).attr('getDescription')));
    $('.createdBy').val(($(this).attr('getCreatedBy')));
    $('.created').val(($(this).attr('getCreated')));
    $('.updatedBy').val(($(this).attr('getUpdatedBy')));
    $('.updated').val(($(this).attr('getUpdated')));
});

$('.getValue').on('change', function (e) {
    e.preventDefault();
    $('.costPrice').val($('.getCostPrice option:selected').val());
    $('.product').val($('.getProductName option:selected').text());
});