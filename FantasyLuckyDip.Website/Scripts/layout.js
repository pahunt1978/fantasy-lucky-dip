$(document).ready(function () {
    var manager = new LayoutManager();
    manager.initialise();
});

function LayoutManager() {
    var eventTimeDiv;
    var timeZone;    

    this.initialise = function () {
        eventTimeDiv = $('#event-time');

        $('#primary-heading').text($('#PrimaryHeadingData').text());
        $('#secondary-heading').text($('#SecondaryHeadingData').text());
        $('#timetable-link').attr("href", $('#TimetableLinkData').text());
        
        timeZone = $('#TimeZoneData').text();
        updateClock();        
    }

    function updateClock() {                
        var eventTime = moment().tz(timeZone).format('ddd HH:mm:ss');
        eventTimeDiv.html(eventTime);
        setTimeout(updateClock, 500);
    }
}