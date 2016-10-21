 (function bookGenerator () {

        let id = 1;
     return function (selector, titleName, authorName, isbn) {

         $(selector).append($('<div>').attr('id', 'book' + id)
             .append($('<p>').addClass('title').text(titleName))
             .append($('<p>').addClass('author').text(authorName))
             .append($('<p>').addClass('isbn').text(isbn))
             .append($('<button>').text('Select').on('click', select))
             .append($('<button>').text('Deselect').on('click', deselect)));

         function select() {
             $(this).parent().css('border', '2px solid blue');
         }

         function deselect() {
             $(this).parent().css('border', '');
         }

         id++;
     }
    }());