$(document).ready(function () {




    //$('#calendar').fullCalendar({
    //    header: {
    //        left: 'prev,next today',
    //        center: 'title',
    //        right: 'month,agendaWeek,agendaDay'
    //    },
    //    lang: "pt-br",
    //    defaultDate: new Date(),
    //    timezone: 'America/Sao_Paulo',
    //    businessHours: {
    //        start: '10:00',
    //        end: '18:00',
    //        dow: [1, 2, 3, 4]
    //    },
    //    editable: true,
    //    eventClick: teste,
    //    events: [
    //    {
    //        id: 1,
    //        title: 'Business Lunch',
    //        start: '2016-06-03T14:00:00',
    //        end: '2016-06-03T16:00:00',
    //        constraint: 'businessHours',
    //        color: '#257e4a',
    //        //overlap: false,
    //    }
    //    ]
    //});

    function teste(e) {
        console.log('## 1', e)
    }

    $(".chosen-select").chosen({
        no_results_text: "Nenhum resultado encontrado."
    });

});
