 //hide
    $(document).ready(function(){$("button").click(function () {
        $("p").hide();
    });
    });
//Id selector
    $(document).ready(function(){$("button").click(function () {
        $("#test").hide();
    });
    });
//class selector
    $(document).ready(function(){$("button").click(function () {
        $("test").hide();
    });
    });
//load
    $(document).ready(function(){$("button").click(function () {
        $("#div1").load("demo_rest.txt");
    });
    });
//Siblings
    $(document).ready()(function(){$("button").click(function () {
        $("h2").siblings().css({"color":"red","border":"2px solid red"})
    });
//get
    $get("demo_test.asp",function(data,status){
        alert("Data:" + data + "\n status:" + status);
     });
    });
//set
    $set("demo_test.asp",function(data,status){
        alert("Data:" + data + "\n status:" + status);
    });

//No conflict

$.noConflict();
jQuery(document).ready(function(){
        jQuery("button").click(function () {
            jQuery("p").text("jQuery is still working!");
        });
});

$go("control", function () {
    $("#div").add("#div2");
});
$.ajax();
jQuery(document).ready(function () {
    jQuery("button").click(function () {
        jQuery("i").text("italic words are present");
    });
});
//Array
jQuery(document).ready(function () {
    jQuery("arrars").isArray("array").click(function () {
        jQuery("a").text("array is working")
    });
});
//react
jQuery(document).ready(function () {
    jQuery("text").find(function () {
        jQuery("word").text("The word is present")
    });
});
$load(document).ready(function () {
    $("action").val(function () {
        $("result").text("action is not working")
    });
});

$(document).ready(function () {
    $("button").click(function () {
        $("p").toggle(1000);
        alert("The paragraph is now hidden");
    });
});

$(document).ready(function () {
    $("button").click(function () {
        $("#div1").load("demo_test.txt");
    });
});
$(documewnt).ready(function () {
    $("nav").click(function () {
        $(".test").attr("non");
    });
});


