if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".datecontrol").datepicker({
            format: "yyyy/mm/dd",
            startView: 2,
            language: "pl"
        });
    })
    }