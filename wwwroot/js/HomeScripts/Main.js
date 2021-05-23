$(document).ready(function ()
{
    $("#cart-items").fadeOut();

    $(".cart").click(function ()
    {
        $("#cart-items").slideToggle();
    });

    $("#items-basket").text("(" + ($("#list-item").children().length) + ")");



    $(".item").click(function ()
    {
        $("#cart-items").fadeIn();

        setTimeout(function ()
        {
            $("#cart-items").fadeOut();
        }, 3000)

        $(this).each(function ()
        {
            var name = $(this).children(".item-detail").children("h4").text();
            var remove = "<button style='color:white; padding:5px' class='remove'> X </button>";
            var moneyVal = "<span style='color:white' class='eachPrice'>" + (parseFloat($(this).children(".item-detail").children(".prices").children(".price").text())) + "</span>";
            $("#list-item").append("<li style='color:white'>" + name + "&#09; - &#09; R " + moneyVal + "&#09;" + remove + "</li>");

            //number of items in basket
            $("#items-basket").text("(" + ($("#list-item").children().length) + ")");
            $("#items-basket").text();

            //calculate total price
            var totalPrice = 0;
            $(".eachPrice").each(function ()
            {
                var itemPrice = parseFloat($(this).text());
                totalPrice += itemPrice;
            });
            $("#total-price").text("R "+totalPrice);
        });

        //remove items from basket
        $(".remove").click(function ()
        {
            $(this).parent().remove();

            var totalPrice = 0;
            $(".eachPrice").each(function ()
            {
                var itemPrice = parseFloat($(this).text());
                totalPrice += itemPrice;
            });
            $("#total-price").text("R "+totalPrice);
            $("#items-basket").text("(" + ($("#list-item").children().length) + ")");
        });
    });
});