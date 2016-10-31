function summary(buttonSelector) {
    $(buttonSelector).on('click', extractSummary);
    
    function extractSummary() {
        let summary = "";
        let strongs = $('#content strong').toArray();
        for(let strong of strongs){
            summary += $(strong).text();
        }
        let parent = $('#content').parent();
        console.log(parent);
        $(parent).append($('<div>').attr('id', 'summary').append($('<h2>').text("Summary")).append($('<p>').text(summary)));
    }
}