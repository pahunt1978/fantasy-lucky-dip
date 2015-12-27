$(document).ready(function () {
    var manager = new LeagueTableManager();
    manager.initialise();
});

function LeagueTableManager() {         
    this.initialise = function () {
        $('body').on('click', '.image', openAthleteDialog);
        $('body').on('click', '.country-image', openCountryDialog);
    }

    function openAthleteDialog() {
        var popupId = '#athlete-popup-' + $(this).data('id');

        var popup = $(popupId).dialog({
            autoOpen: false,
            width: 'auto',
            modal: true
        });

        popup.dialog("open");

        // Remove focus from close button which looks weird in Chrome
        $('.ui-dialog :button').blur();
    }

    function openCountryDialog() {
        var popupId = '#country-popup-' + $(this).data('id');

        var popup = $(popupId).dialog({
            autoOpen: false,
            width: 'auto',
            modal: true
        });

        popup.dialog("open");

        // Remove focus from close button which looks weird in Chrome
        $('.ui-dialog :button').blur();
    }
}