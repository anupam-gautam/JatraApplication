var EventsDetail = function () {
    var me = this;


    this.init = function () {
        $('body').on('click', '#calendardays', function () {
            $("#calendar #calendardays li").on('click', function () {
                var eventId = $(this).attr("data-eventId");
                debugger
                $.ajax({
                    type: 'POST',
                    url: me.getEventDetailUrl,
                    data: { eventId : eventId },
                    dataType: 'html',
                    success: function (data) {
                        debugger
                        $('body').append(data);
                    },
                    error: function (error) {
                        debugger
                    }
                });

            });
        });
    }
}