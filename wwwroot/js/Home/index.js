//alert("Dneme");

var testDiv = $("#testDiv");

$("#testDiv").append("Hafta 13");

$('#p3').css("color", "red").css("background","blue");

$('.p2').css("color", "blue");

$('.p2').append(" asdasd");

//$('#p3').hide();

$('button').css("color", "red");
$('button').prop("disabled", false);

//$('input[type=button]').css("color", "blue");
//$('input[type=button], button').css("color", "blue");

$(':button').css("color", "blue");
//$('p').css("background", "yellow");

$('tr:even').css("background", "blue");
$('tr:odd').css("background", "yellow");

$('#ad').addClass("form-control");

setTimeout(function () {
    $('#ad').removeClass("form-control");
}, 2000);

$('#soyad').prop("disabled", true);

//$('#testDiv').hide(2000);
$('p:first').css("background","blue");
$('p:first').hide(2000, function () {
    console.log("bitti");
});
//$('p:last').hide();

$('p:last').css("background", "blue");
//$('p:last').slideUp(2000, function () {
//    $('p:last').slideDown(2000);
    
//});

$('p:last').slideUp(2000).slideDown(2000);


var ad = $('#ad').val();
console.log(ad);
//alert(ad);


var deneme = $('#ad').attr("deneme");
console.log(deneme);

var aText = $('#aciklamaSpan').text();
console.log(aText);

var htmlAText = $('#aciklamaSpan').html();
console.log(htmlAText);

var valueAText = $('#aciklamaSpan').val();
console.log(valueAText);


$('#aciklamaSpan').text("<b>Jquery tarafından değiştiridi</b>");
$('#aciklamaSpan').html("<b>Jquery tarafından değiştiridi</b>");
$('#ad').val("Ahmet");

$('#aktiflik').val(true);
$('#aktiflik').prop("checked", true);

$('#il').val(2);

var ilKodu = $('#il').val();
//alert(ilKodu);

var ilAdi= $('#il option:selected').text();
//alert(ilAdi);

$("#btnSil").click(function () {
    alert("tıklandı");
});

$("#btnGoster").click(function () {
    $('#testTable').slideDown(1000);
});

$("#btnGizle").click(function () {
    $('#testTable').slideUp(1000);
});


$("#ad").blur(function () {
    console.log("blur: " + $("#ad").val());
});

$("#ad").change(function () {
    console.log("change: " + $("#ad").val());
});

$(document).ready(function () {
    $.get("https://localhost:7103/Home/GetIller", function (data) {
        var il = $('#il');
        il.empty();
        il.append($('<option></option>')
            .text("Seçiniz")
            .val(-1));

        console.debug(data);
        $.each(data, function (index, item) {
            il.append($('<option></option>')
                .text(item.ad)
                .val(item.id));
        });
    });
});


$('#il').change(function () {
    debugger;

    var seciliIlKodu = $('#il').val();
    var ilce = $('#ilce');
    var ilceDiv = $("#ilceDiv");
    
    ilce.empty();
    if (seciliIlKodu == -1) {
        ilceDiv.slideUp(1000);
    }
    else {

        var postParameters = { "IlId" : seciliIlKodu };
        $.post("https://localhost:7103/Home/GetIlcelerPost", postParameters , function (data) {

            $.each(data, function (index, item) {
                ilce.append($('<option></option>')
                    .text(item.ad)
                    .val(item.id));
            });

            ilceDiv.slideDown(1000);
        });
        //$.get("https://localhost:7103/Home/GetIlceler/" + seciliIlKodu, function (data) {
            
        //    $.each(data, function (index, item) {
        //        ilce.append($('<option></option>')
        //            .text(item.ad)
        //            .val(item.id));
        //    });

        //    ilceDiv.slideDown(1000);
        //});
    }
    
});

$('#il').addClass("form-control");
$('#ilce').addClass("form-control");

$("#btnKaydet").click(function () {
    debugger;

    var result = $("#frmTest").serialize();
    var result2 = $("#frmTest").serializeArray();

    var postParameters = {};
    $.each(result2, function (index, item) {
        postParameters[item.name] = item.value;
    });

    $.post("https://localhost:7160/Home/Index", postParameters, function (data) {
        console.log("Post edildi");
    });

});