jQuery(document).ready(function($){
    //final width --> this is the quick view image slider width
    //maxQuickWidth --> this is the max-width of the quick-view panel
    var sliderFinalWidth = 400,
        maxQuickWidth = 900;

    var dataAttr;
    //open the quick view panel
    $('.cd-trigger').on('click', function(event){
        $('.cd-slider').find('.selected').removeClass('selected');
        var selectedImage = $(this).parent().parent().find('img'),
            slectedImageUrl = selectedImage.attr('src'),
            dataAttr = selectedImage.attr('data-type');

        $('.cd-slider').css('display', 'none');
        $('.cd-slider.' + dataAttr).css('display', 'block');

        $('body').addClass('overlay-layer');
        animateQuickView(selectedImage, sliderFinalWidth, maxQuickWidth, 'open');

        //update the visible slider image in the quick view panel
        //you don't need to implement/use the updateQuickView if retrieving the quick view data with ajax
        updateQuickView(slectedImageUrl, dataAttr);
    });

    //close the quick view panel
    $('body').on('click', function(event){
        if( $(event.target).is('.cd-close') || $(event.target).is('body.overlay-layer')) {
            closeQuickView( sliderFinalWidth, maxQuickWidth);
        }
    });
    $(document).keyup(function(event){
        //check if user has pressed 'Esc'
        if(event.which=='27'){
            closeQuickView( sliderFinalWidth, maxQuickWidth);
        }
    });

    //quick view slider implementation
    $('.cd-quick-view').on('click', '.cd-slider-navigation a', function(){

        updateSlider($(this));
    });

    //center quick-view on window resize
    $(window).on('resize', function(){
        if($('.cd-quick-view').hasClass('is-visible')){
            window.requestAnimationFrame(resizeQuickView);
        }
    });

    function updateSlider(navigation) {
        dataAttr = $('li.selected').parent('.cd-slider').attr('class').slice(-1);

        var sliderConatiner = navigation.parents('.cd-slider-wrapper').find('.cd-slider.' + dataAttr),
            activeSlider = sliderConatiner.children('.selected').removeClass('selected');

        if ( navigation.hasClass('cd-next') ) {
            ( !activeSlider.is(':last-child') ) ? activeSlider.next().addClass('selected') : sliderConatiner.children().eq(0).addClass('selected');
        } else {
            ( !activeSlider.is(':first-child') ) ? activeSlider.prev().addClass('selected') : sliderConatiner.children().last().addClass('selected');
        }
    }

    function updateQuickView(url, dataAttr) {
        $('.cd-quick-view .cd-slider.' + dataAttr +' li').removeClass('selected').find('img[src="'+ url +'"]').parent('li').addClass('selected');
    }

    function resizeQuickView() {
        var quickViewLeft = ($(window).width() - $('.cd-quick-view').width())/2,
            quickViewTop = ($(window).height() - $('.cd-quick-view').height())/2;
        $('.cd-quick-view').css({
            "top": quickViewTop,
            "left": quickViewLeft,
        });
    }

    function closeQuickView(finalWidth, maxQuickWidth) {
        var close = $('.cd-close'),
            activeSliderUrl = close.siblings('.cd-slider-wrapper').find('.selected img').attr('src'),
            selectedImage = $('.empty-box').find('img');
        //update the image in the gallery
        if( !$('.cd-quick-view').hasClass('velocity-animating') && $('.cd-quick-view').hasClass('add-content')) {
            selectedImage.attr('src', activeSliderUrl);
            animateQuickView(selectedImage, finalWidth, maxQuickWidth, 'close');
        } else {
            closeNoAnimation(selectedImage, finalWidth, maxQuickWidth);
        }
    }

    function animateQuickView(image, finalWidth, maxQuickWidth, animationType) {
        //store some image data (width, top position, ...)
        //store window data to calculate quick view panel position
        var parentListItem = image.parent().parent().parent('.cd-item'),
            topSelected = image.offset().top - $(window).scrollTop(),
            leftSelected = image.offset().left,
            widthSelected = image.width(),
            heightSelected = image.height(),
            windowWidth = $(window).width(),
            windowHeight = $(window).height(),
            finalLeft = (windowWidth - finalWidth)/2,
            finalHeight = finalWidth * heightSelected/widthSelected,
            finalTop = (windowHeight - finalHeight)/2,
            quickViewWidth = ( windowWidth * .8 < maxQuickWidth ) ? windowWidth * .8 : maxQuickWidth ,
            quickViewLeft = (windowWidth - quickViewWidth)/2;

        if( animationType == 'open') {
            //hide the image in the gallery
            parentListItem.addClass('empty-box');
            //place the quick view over the image gallery and give it the dimension of the gallery image
            $('.cd-quick-view').css({
                "top": topSelected,
                "left": leftSelected,
                "width": widthSelected,
            }).velocity({
                //animate the quick view: animate its width and center it in the viewport
                //during this animation, only the slider image is visible
                'top': finalTop+ 'px',
                'left': finalLeft+'px',
                'width': finalWidth+'px',
            }, 1000, [ 400, 20 ], function(){
                //animate the quick view: animate its width to the final value
                $('.cd-quick-view').addClass('animate-width').velocity({
                    'left': quickViewLeft+'px',
                    'width': quickViewWidth+'px',
                }, 300, 'ease' ,function(){
                    //show quick view content
                    $('.cd-quick-view').addClass('add-content');

                    var dataToShow;

                    if($('li.selected').length > 0)  {
                        dataToShow = $('li.selected').parent('.cd-slider').attr('class').slice(-1);
                    }

                    if(dataToShow == 'a') {
                        $('.add-content .cd-item-info h2').text('Das Keyboard HackShield RFID Backpack');
                        $('.add-content .cd-item-info p').text("The Das Keyboard Hack Shield RFID Backpack protects not only from RFID waves, but electromagnetic waves of any kind! So if you put your mobile phone, smartphone, UMTS-enabled tablet or notebook into the HackShield Backpack, you can't be found anymore (though that also means, you can't be called). ")
                    } else if (dataToShow == 'b') {
                        $('.add-content .cd-item-info h2').text('CSS Puns Ninja');
                        $('.add-content .cd-item-info p').text("Since we couldn't solve the dilemma between nerds who want to be invisible and nerds who want to shout out their nerdiness, we have provided you with the code for a perfect ninja appearance. It nearly turns every owner into a ninja ;).")
                    } else if (dataToShow == 'c') {
                        $('.add-content .cd-item-info h2').text('Matias Ergo Pro Keyboard');
                        $('.add-content .cd-item-info p').text("The Matias Ergo Pro might be the most adaptable of all keyboards. It's high quality boasts several features and is perfect for those who type a lot and don't want carpal tunnel syndrome or tired fingers! ")
                    } else if (dataToShow == 'd') {
                        $('.add-content .cd-item-info h2').text('Bath Towel Binary');
                        $('.add-content .cd-item-info p').text("Who's got the coolest towel on the beach or at the pool? Answer: scientists/geniuses/geeks/nerds! If you, the smart computer scientist/genius/geek/nerd (delete as appropriate) are, as we speak, about to invest in a proper towel to suit your status, then we have the best option! :).  ")
                    } else if (dataToShow == 'e') {
                        $('.add-content .cd-item-info h2').text('Retro Games Controller');
                        $('.add-content .cd-item-info p').text("Do mods more real than reality just annoy you? And is completing the 300th side quest less than a thrill? Or maybe your internet connection isn't great? Or your mother accidentally bought you a Mac Book for gaming? ;) Whatever your issue is, maybe it's time to go back to the roots. ")
                    }
                });
            }).addClass('is-visible');
        } else {
            //close the quick view reverting the animation
            $('.cd-quick-view').removeClass('add-content').velocity({
                'top': finalTop+ 'px',
                'left': finalLeft+'px',
                'width': finalWidth+'px',
            }, 300, 'ease', function(){
                $('body').removeClass('overlay-layer');
                $('.cd-quick-view').removeClass('animate-width').velocity({
                    "top": topSelected,
                    "left": leftSelected,
                    "width": widthSelected,
                }, 500, 'ease', function(){
                    $('.cd-quick-view').removeClass('is-visible');
                    parentListItem.removeClass('empty-box');
                });
            });
        }
    }
    function closeNoAnimation(image, finalWidth, maxQuickWidth) {
        var parentListItem = image.parent('.cd-item'),
            topSelected = image.offset().top - $(window).scrollTop(),
            leftSelected = image.offset().left,
            widthSelected = image.width();

        //close the quick view reverting the animation
        $('body').removeClass('overlay-layer');
        parentListItem.removeClass('empty-box');
        $('.cd-quick-view').velocity("stop").removeClass('add-content animate-width is-visible').css({
            "top": topSelected,
            "left": leftSelected,
            "width": widthSelected,
        });
    }
});