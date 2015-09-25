var size = 0;
$("document").ready(function () {
    $("#picone").css("cursor", "zoom-in");
    $("#picone").click(function () {
        if (size == 0) {
            $("#picone").animate({ width: 300 }, 1000, "easeOutElastic");
            size = 1;
            $("#picone").css("cursor", "zoom-out");
        } else {
            $("#picone").animate({ width: 150 }, 1000, "easeOutElastic");
            size = 0;
            $("#picone").css("cursor", "zoom-in");
        }
    });
});