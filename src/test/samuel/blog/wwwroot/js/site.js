// site js

(function (){
    // var ele = $("#username");

    // ele.text("new user name");

    var $sidebarAndWarrper = $("#sidebar,#wrapper");
    $("#sidebarToggle").on("click", function() {
        $sidebarAndWarrper.toggleClass("hide-sidebar");
        if($sidebarAndWarrper.hasClass("hide-sidebar")) {
            $(this).text("Show");
        } else {
            $(this).text("Hide");
        } 
    });

})();