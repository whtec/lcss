﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryDetails.aspx.cs" Inherits="Salary_SalaryDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人工资单</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="../favicon.ico">
    <link href="../Styles/VerticalTimeline/css/default.css" rel="stylesheet" />
    <link href="../Styles/VerticalTimeline/css/component.css" rel="stylesheet" />
    <script src="../Styles/VerticalTimeline/js/modernizr.custom.js"></script>
    <script type="text/javascript" >
        $(function () {

        });
        function mysalary(url) {
            $.getJSON(url, { Rnd: Math.random() },
            function (json) {
                
            });
        }
    </script>
</head>
<body>
    <div class="row">
        <div class="main">
            <ul class="cbp_tmtimeline">
                <li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>4月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h2>Ricebean black-eyed pea</h2>
                        <div class="scheme-content">
                            <div class="cat" style="border-top: 0;">
                                <div class="cat-title">应发项目</div>
                                <div class="cat-content"><span class="project" title="基本工资">基本工资</span><span class="pay" style="color: green; text-align: right;">3000.00</span><span class="project" title="岗位工资">岗位工资</span><span class="pay" style="color: green; text-align: right;">4000.00</span><span class="project" title="绩效工资">绩效工资</span><span class="pay" style="color: green; text-align: right;">2000.00</span><span class="project" title="年功工资">年功工资</span><span class="pay" style="color: green; text-align: right;">200.00</span><span class="project" title="加班工资">加班工资</span><span class="pay" style="color: green; text-align: right;">300.00</span></div>
                            </div>
                            <div class="cat" style="border-top: 0;">
                                <div class="cat-title">扣款项目</div>
                                <div class="cat-content"><span class="project" title="养老保险">养老保险</span><span class="pay" style="color: green; text-align: right;">720.00</span><span class="project" title="失业保险">失业保险</span><span class="pay" style="color: green; text-align: right;">20.00</span><span class="project" title="医疗保险">医疗保险</span><span class="pay" style="color: green; text-align: right;">120.00</span><span class="project" title="考勤扣款">考勤扣款</span><span class="pay" style="color: green; text-align: right;">0.00</span><span class="project" title="其他扣款">其他扣款</span><span class="pay" style="color: green; text-align: right;">0.00</span><span class="project" title="代扣税">代扣税</span><span class="pay" style="color: green; text-align: right;">750.00</span></div>
                            </div>
                            <div class="cat" style="border-top: 0;">
                                <div class="cat-title">其他项目</div>
                                <div class="cat-content"><span class="project" title="事假扣款">事假扣款</span><span class="pay" style="color: green; text-align: right;">100.00</span><span class="project" title="病假扣款">病假扣款</span><span class="pay" style="color: green; text-align: right;">0.00</span><span class="project" title="代扣税基数">代扣税基数</span><span class="pay" style="color: green; text-align: right;">0.00</span></div>
                            </div>
                            <div class="total">
                                <div class="cat-title">合计：</div>
                                <span class="project" onmouseover="this.title=this.innerText" title="扣款合计">扣款合计</span><span class="pay" style="color: green; text-align: right;">0.00</span><span class="project" onmouseover="this.title=this.innerText">应发合计</span><span class="pay" style="color: green; text-align: right;">10000.00</span><span class="project" onmouseover="this.title=this.innerText">实发合计</span><span class="pay" style="color: green; text-align: right;">9250.00</span></div>
                        </div>
                    </div>
                </li>
                <li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>3月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h2>Greens radish arugula</h2>
                        <p>Caulie dandelion maize lentil collard greens radish arugula sweet pepper water spinach kombu courgette lettuce. Celery coriander bitterleaf epazote radicchio shallot winter purslane collard greens spring onion squash lentil. Artichoke salad bamboo shoot black-eyed pea brussels sprout garlic kohlrabi.</p>
                    </div>
                </li>
                <li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>2月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h2>Sprout garlic kohlrabi</h2>
                        <p>Parsnip lotus root celery yarrow seakale tomato collard greens tigernut epazote ricebean melon tomatillo soybean chicory broccoli beet greens peanut salad. Lotus root burdock bell pepper chickweed shallot groundnut pea sprouts welsh onion wattle seed pea salsify turnip scallion peanut arugula bamboo shoot onion swiss chard. Avocado tomato peanut soko amaranth grape fennel chickweed mung bean soybean endive squash beet greens carrot chicory green bean. Tigernut dandelion sea lettuce garlic daikon courgette celery maize parsley komatsuna black-eyed pea bell pepper aubergine cauliflower zucchini. Quandong pea chickweed tomatillo quandong cauliflower spinach water spinach.</p>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</body>
</html>
