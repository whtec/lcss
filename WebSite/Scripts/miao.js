$(document).ready(function () {
    //  console.log("abb");
    // $('#loadContent').load('Salary/Incomedetails.html');
})

function zoom(zoomvalue) {

    $(document.body).css("zoom", zoomvalue);
}

$.ajaxSetup({
    global: false,
    async: false,
    // cache: false,
});

function ajaxStartIndex() {
    $(document).ajaxStart(function () {
        $('#loadContent').html('<img id="ajaxStart" class="lodingimg1" src="Image/712.GIF"  />');
    });
}



function indexleft(id, url) {
    $(id).click(function () {
        $('#loadTittle').text($(id).text());
        ajaxStartIndex();
        $('#loadContent').load(url);
        $('#accordion').find("li").removeClass("active");
        $(id).parent('li').addClass("active");;
    })
}

$(document).ready(function () {

    indexleft("#gzdr", 'Salary/LoadSalary.aspx');
    indexleft("#jxdr", 'Salary/LoadSalary.aspx');
    indexleft("#fldr", 'Salary/LoadSalary.aspx');
    indexleft("#drls", 'Salary/SalaryLineList.aspx?call=2');

    indexleft("#rgcb", 'Salary/SalaryLineList.aspx?call=1');
    indexleft("#grsr", 'Salary/SalaryLineList.aspx?call=3');
    indexleft("#srgs", 'Salary/SalaryLineList.aspx?call=3');
    indexleft("#srmx", 'Salary/SalaryDetails.aspx');

})

$(document).ready(function () {
    //$("#rgcb").click(function () {
    //    $('#loadTittle').text($('#rgcb').text()); ajaxStartIndex();

    //    //$.get("Salary/SalaryLineList.aspx", { call: "2" }, function (result) {
    //    //    console.log(result);
    //    //    $("#loadContent").html(result);
    //    //});

    //    $('#loadContent').load("Salary/SalaryLineList.aspx?call=1");
    //    $('#accordion').find("li").removeClass("active");
    //    $('#rgcb').parent('li').addClass("active");;
    //})

})

//$(document).ready(function () {
//    $("#dateup").change(function () {
//        console.log("abb");
//        $('#datedown').val($('#dateup').val());
//        $("#datedown").removeAttr("disabled");
//    })
//})

//$(document).ready(function () {
//    $("#btnRead").click(function () {
//        // console.log("abb");
//        // $("#btnImport").removeAttr("disabled");
//        //   $('div.alert').remove();
//    })
//})