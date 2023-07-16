var EventsDetail = function () {
    var me = this;


    this.init = function () {
        $('body').on('click', '#calendardays', function () {
            $("#calendar #calendardays li").on('click', function () {
                var eventId = $(this).attr("data-eventId");
                window.location.replace("https://localhost:7075/Event/GetEventDetails?eventId=" + eventId);
                debugger
            });
           
        });
    }
}