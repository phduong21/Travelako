function updateTotalCost() {
    var c = document.getElementById("CouponCode").value;
    var g = document.getElementById("GuestSize").value;
    var p = document.getElementById("pricePer").dataset.price;
    var totalCost = 0;
    var discount = 0;
    if ((c == null || c == undefined || c == 0) && (g != null && g != undefined && g != 0)) {
        totalCost = g * p;
    }
    else if ((g == null || g == undefined || g == 0) && (c != null && c != undefined && c != 0)) {
        discount = c * p / 100;
        totalCost = p - discount;
        document.getElementById("discount").innerHTML = "-$ " + discount + " (" + c + "%)";
    }
    else {
        discount = c * g * p / 100;
        totalCost = (g * p) - discount;
        document.getElementById("discount").innerHTML = "-$ " + discount + " (" + c + "%)";
    }
    document.getElementById("totalCost").innerHTML = "$ " + totalCost;
}

document.getElementById("GuestSize").addEventListener('change', updateTotalCost);

//window.addEventListener("load", (event) => {
//    var c = document.getElementById("CouponCode");
//    var p = document.getElementById("pricePer");
//    if (c != null && c != undefined && p != null && p != undefined) {
//        var discount = 0;
//        discount = c * p / 100;
//        totalCost = p - discount;
//        document.getElementById("discount").innerHTML = "-$ " + discount + " (" + c + "%)";
//        document.getElementById("totalCost").innerHTML = "$ " + totalCost;
//    }
//});