$(document).ready(function () {
  'use strict';

  var fullCalendar = $('#calendar');
  var eventForRollBack = {};

  $('#bt_buscar').on('click', function() {
    $.post('/Agenda/Buscar', getFiltros())
      .done(function(data) {
        initFullCalendar(data);
        initDateTimePickers(data);
      });
  });

  $('#bt_cancelar').on('click', function() {
    $('#consultaModal').modal('hide');
  });

  $('#bt_salvar').on('click', function() {
    var consulta = generateConsulta();

    if (consulta.Id) {
      update(consulta);
    } else {
      create(consulta);
    }
  });

  $('#bt_excluir').on('click', function() {
    var id = $('#IdConsulta').val();

    $.post('/Agenda/Delete/' + id)
      .done(function(data) {
        toastr.success('Consulta excluída com sucesso.');
      });

    fullCalendar.fullCalendar( 'removeEvents', id );
    $('#consultaModal').modal('hide');
  });

  function eventDrag(event, jsEvent, ui, view) {
    var consulta = {
      Id: event.id,
      DataDaConsulta: event.start.format(),
      TipoConsulta: event.tipoConsuta,
      IdPaciente: event.idPaciente,
      IdMedico: $('#IdMedico').val(),
    }

    update(consulta)
      .fail(function(err) {
        eventRollBackStart();
      })
  }

  function create(consulta) {
    $.post('/Agenda/Create', consulta)
      .done(function(data) {
        addConsultaNoCalendario(data);
        toastr.success('Consulta salva com sucesso.');
      })
      .fail(function(err) {
        if (err.responseJSON === 'NO_CONSULTA_IN_LAST_DAYS') {
          toastr.error('O Paciente não teve uma consulta nos ultimos 30 dias.');
        }
      })
  }

  function update(consulta) {
    return $.post('/Agenda/Update', consulta)
      .done(function(data) {
        updateConsultaNoCalendario(data);
        toastr.success('Consulta salva com sucesso.');
      })
      .fail(function(err) {
        if (err.responseJSON === 'NO_CONSULTA_IN_LAST_DAYS') {
          toastr.error('O Paciente não teve uma consulta nos ultimos 30 dias.');
        }
      })
  }

  function eventRollBackStart() {
    var event = {
        id: eventForRollBack.id,
        title: eventForRollBack.title,
        start:eventForRollBack.start,
        constraint: 'businessHours',
        color: resolveColor(eventForRollBack.tipoConsuta),
        idPaciente: eventForRollBack.idPaciente,
        tipoConsuta: eventForRollBack.tipoConsuta
    }

    fullCalendar.fullCalendar( 'removeEvents', event.id );
    fullCalendar.fullCalendar( 'addEventSource', [event] );
  }

  function generateConsulta() {
    return {
      Id: $('#IdConsulta').val(),
      DataDaConsulta: $('#calendar').fullCalendar('getDate').format(),
      TipoConsulta: $('#TipoConsulta').val(),
      IdPaciente: $('#IdPacienteConsulta').val(),
      IdMedico: $('#IdMedico').val(),
    };
  }

  function updateConsultaNoCalendario(data) {
    var event = {
        id: data.Id,
        title: data.Paciente.Nome,
        start: new Date(parseInt(data.DataDaConsulta.replace("/Date(", "").replace(")/",""), 10)),
        constraint: 'businessHours',
        color: resolveColor(data.TipoConsulta),
        idPaciente: data.Paciente.Id,
        tipoConsuta: data.TipoConsulta
    }

    fullCalendar.fullCalendar( 'removeEvents', event.id );
    fullCalendar.fullCalendar( 'addEventSource', [event] );
    $('#consultaModal').modal('hide');

  }

  function addConsultaNoCalendario(data) {
    var event = {
        id: data.Id,
        title: data.Paciente.Nome,
        start: $('#calendar').fullCalendar('getDate').format(),
        constraint: 'businessHours',
        color: resolveColor(data.TipoConsulta),
        idPaciente: data.Paciente.Id,
        tipoConsuta: data.TipoConsulta
    }

    fullCalendar.fullCalendar( 'addEventSource', [event] );
    $('#consultaModal').modal('hide');
  }

  function resolveColor(tipoConsulta) {
    var color = '#257e4a';

    if (tipoConsulta === 'Reconsulta') {
      color = '#752323';
    }

    else if (tipoConsulta === 'Consulta de Rotina') {
      color = '#8B8B8B';
    }

    return color;
  }

  function initDateTimePickers(data) {
    var options = {
      sideBySide: true,
      daysOfWeekDisabled: data.diasDaSemana,
    }

    $('#datetimeInicioConsulta').datetimepicker(options);
    $('#datetimeFimConsulta').datetimepicker(options);
  }

  function initFullCalendar(data) {
    $('#calendar').fullCalendar({
       header: {
           left: 'prev,next today',
           center: 'title',
           right: 'month,agendaDay'
       },
       lang: 'pt-br',
       timezone: 'America/Sao_Paulo',
       defaultDate: new Date(),
       aspectRatio: 1.8,
       minTime: data.HrInicio,
       maxTime: data.HrFim,
       slotLabelFormat: ['HH:mm'],
       defaultTimedEventDuration: data.DuracaoConsulta,
       slotDuration: data.DuracaoConsulta,
       slotLabelInterval: data.DuracaoConsulta,
       businessHours: {
           start: data.HrInicio,
           end: data.HrFim,
           dow: data.diasDaSemana
       },
       dayClick: dayClick,
       eventClick: eventClick,
       eventDrop: eventDrag,
       eventDragStart: eventRollBack,
       eventLimit: true,
       editable: true,
       selectable: true,
       events: []
    });

    generateConsultas(data.Agendamentos);
  }

  function eventRollBack(event) {
    for (var p in event) {
      eventForRollBack[p] = event[p];
    }
  }

  function generateConsultas(agendamentos) {
    var consultas = [];

    if (agendamentos && agendamentos.length > 0) {
      agendamentos.forEach(function(a) {
        consultas.push({
              id: a.Id,
              title: a.Paciente.Nome,
              start: new Date(parseInt(a.DataDaConsulta.replace("/Date(", "").replace(")/",""), 10)),
              color: resolveColor(a.TipoConsulta),
              constraint: 'businessHours',
              idPaciente: a.Paciente.Id,
              tipoConsuta: a.TipoConsulta
        })
      });
    }

    fullCalendar.fullCalendar( 'addEventSource', consultas );
  }

  function eventClick(event) {
    var nomeMedico = $('#IdMedico :selected').text();

    $('#dataConsulta').text(event.start.format('LLLL'));
    $('#nomeMedico').text(nomeMedico);
    $('#IdConsulta').val(event.id);
    $('#IdPacienteConsulta').val(event.idPaciente);
    $('#IdPacienteConsulta').trigger("chosen:updated");
    $('#TipoConsulta').val(event.tipoConsuta);
    $('#TipoConsulta').trigger("chosen:updated");

    fullCalendar.fullCalendar('gotoDate', event.start);

    $('#bt_excluir').removeClass('hide');
    $('#consultaModal').modal('show');
  }

    function dayClick(date, jsEvent, view) {
      fullCalendar.fullCalendar('gotoDate', date);

      if (fullCalendar.fullCalendar('getView').name === 'month') {
        fullCalendar.fullCalendar('changeView', 'agendaDay');
      } else {
          var nomeMedico = $('#IdMedico :selected').text();
          var IdPaciente = $('#IdPaciente').val();

          $('#IdConsulta').val(null);
          $('#dataConsulta').text(date.format('LLLL'));
          $('#nomeMedico').text(nomeMedico);
          $('#IdPacienteConsulta').val(IdPaciente);
          $('#IdPacienteConsulta').trigger("chosen:updated");
          $('#TipoConsulta').val(null);
          $('#TipoConsulta').trigger("chosen:updated");

          $('#bt_excluir').addClass('hide');
          $('#consultaModal').modal('show');
      }
  }

  function getFiltros() {
    return {
      IdMedico: $('#IdMedico').val(),
      IdPacinte: $('#IdPaciente').val(),
    }
  }

  $('.chosen-select').chosen({
    allow_single_deselect: true,
    no_results_text: 'Nenhum resultado encontrado.'
  });
});
