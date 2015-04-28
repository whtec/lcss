$(document).ready(function () {
    console.log("abb");
   // $('#loadContent').load('Salary/Incomedetails.html');
})

$(document).ready(function () {
    $("#gzdr").click(function () {
        $('#loadTittle').text($('#gzdr').text());
        window.location.href = "Salary/LoadSalary.aspx";
        //$('#loadContent').load('Salary/LoadSalary.aspx');
        $('#accordion').find("li").removeClass("active");
        $('#gzdr').parent('li').addClass("active");;
    })

    $("#jxdr").click(function () {
        $('#loadTittle').text($('#jxdr').text());
        window.location.href = "Salary/LoadSalary.aspx"; //$('#loadContent').load('Salary/LoadSalary.aspx');
        $('#accordion').find("li").removeClass("active");
        $('#jxdr').parent('li').addClass("active");;
    })

    $("#fldr").click(function () {
        $('#loadTittle').text($('#fldr').text());
        window.location.href = "Salary/LoadSalary.aspx"; //$('#loadContent').load('Salary/LoadSalary.aspx');
        $('#accordion').find("li").removeClass("active");
        $('#fldr').parent('li').addClass("active");;
    })

    $("#drls").click(function () {
        $('#loadTittle').text($('#drls').text());
        window.location.href = "Salary/SalaryLineList.aspx?call=2"; //$('#loadContent').load('Salary/SalaryLineList.aspx?call=2');
        $('#accordion').find("li").removeClass("active");
        $('#fldr').parent('li').addClass("active");;
    })
})

$(document).ready(function () {
    $("#rgcb").click(function () {
        $('#loadTittle').text($('#rgcb').text());
        alert(1);
        window.location.href = "Salary/SalaryLineList.aspx?call=1"; //$('#loadContent').load('Salary/SalaryLineList.aspx?call=1');
        $('#accordion').find("li").removeClass("active");
        $('#rgcb').parent('li').addClass("active");;
    })

    $("#grsr").click(function () {
        $('#loadTittle').text($('#grsr').text());
        window.location.href = "Salary/Incomedetails.html"; //$('#loadContent').load('Salary/Incomedetails.html');
        $('#accordion').find("li").removeClass("active");
        $('#grsr').parent('li').addClass("active");;
    })

    $("#srgs").click(function () {
        $('#loadTittle').text($('#srgs').text());
        window.location.href = "Salary/SalaryLineList.aspx?call=3"; //$('#loadContent').load('Salary/SalaryLineList.aspx?call=3');
        $('#accordion').find("li").removeClass("active");
        $('#srgs').parent('li').addClass("active");;
    })

    $("#srmx").click(function () {
        $('#loadTittle').text($('#srmx').text());
        window.location.href = "Salary/SalaryLineList.aspx?call=3"; //$('#loadContent').load('Salary/SalaryLineList.aspx?call=3');
        $('#accordion').find("li").removeClass("active");
        $('#srmx').parent('li').addClass("active");;
    })
})



$(document).ready(function () {
    $("#dateup").change(function () {
        console.log("abb");
        $('#datedown').val($('#dateup').val());
        $("#datedown").removeAttr("disabled");
    })
})

$(document).ready(function () {
    $("#btnRead").click(function () {
       // console.log("abb");
        // $("#btnImport").removeAttr("disabled");
     //   $('div.alert').remove();
    })
})