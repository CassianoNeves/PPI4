$(document).ready(function () {
  'use strict';

  var fullCalendar = $('#calendar');
    $( '#bt_buscar' ).on( 'click', function() {
      $.post('/Agenda/Buscar', getFiltros())
        .done(function(data) {
          initFullCalendar(data);
        });
    });

    function initFullCalendar(data) {
      $('#calendar').fullCalendar({
         header: {
             left: 'prev,next today',
             center: 'title',
             right: 'month,agendaDay'
         },
         lang: 'pt-br',
         defaultDate: new Date(),
         slotLabelInterval: '00:30',
         slotLabelFormat: ['HH:mm'],
         aspectRatio: 1.8,
         minTime: data.HrInicio,
         maxTime: data.HrFim,
         slotDuration: data.DuracaoConsulta,
         timezone: 'America/Sao_Paulo',
         businessHours: {
             start: data.HrInicio,
             end: data.HrFim,
             dow: data.diasDaSemana
         },
         dayClick: dayClick,
         eventLimitClick: teste,
         editable: true,
         selectable: true,

        //  eventClick: teste,
         events: [
         {
             id: 1,
             title: 'Business Lunch',
             start: '2016-06-03T14:00:00',
             end: '2016-06-03T16:00:00',
             constraint: 'businessHours',
            //  color: '#257e4a'
         }
         ]
      });
    }

    function teste(cellInfo, jsEvent) {
      console.log(cellInfo)
      console.log(jsEvent)
    }

    function dayClick(date, jsEvent, view) {
      if (fullCalendar.fullCalendar('getView').name === 'month') {
        fullCalendar.fullCalendar('gotoDate', date)
        fullCalendar.fullCalendar('changeView', 'agendaDay');
      } else {

      }
    }

    function getFiltros() {
      return {
        IdMedico: $('#IdMedico').val(),
        IdPacinte: $('#IdPaciente').val(),
      }
    }

    $('.chosen-select').chosen({
        no_results_text: 'Nenhum resultado encontrado.'
    });

});
