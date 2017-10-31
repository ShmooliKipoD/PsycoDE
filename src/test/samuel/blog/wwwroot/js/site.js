﻿// site js

(function (){
    // var ele = $("#username");

    // ele.text("new user name");

    var $sidebarAndWarrper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa")
    $("#sidebarToggle").on("click", function() {
        $sidebarAndWarrper.toggleClass("hide-sidebar");
        if($sidebarAndWarrper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        } 
    });

})();