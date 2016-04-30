// Bind to scroll
$(window).scroll(function() {
    // Get container scroll position
    var fromTop = $(this).scrollTop() + topMenuHeight;

    // Get id of current scroll item
    var cur = scrollItems.map(function() {
        if ($(this).offset().top < fromTop)
            return this;
    });
    // Get the id of the current element
    cur = cur[cur.length - 1];
    var id = cur && cur.length ? cur[0].id : "";

    if (lastId !== id) {
        lastId = id;
        // Set/remove active class
        menuItems
            .parent().removeClass("active")
            .end().filter("[href=#" + id + "]").parent().addClass("active");
    }

var item = $('#back-to-top')
    if ($(this).scrollTop() > ($(this).height() / 3)) {
        item.fadeIn('slow');
    } else {
        item.fadeOut('slow');
    }

});

$(function() {
    $(window).scroll(function() {
        if ($(".navbar").offset().top > $(window).height()) {
            $(".navbar-purity").addClass("sticky");
        } else {
            $(".navbar-purity").removeClass("sticky");
        }
    });

});

