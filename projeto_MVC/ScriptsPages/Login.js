(function() {
  'use strict';

  $('#bt_login').on('click', function() {
    $(this).addClass('load')

    var credentials = getCredentials();

    if (!isValidOperation()) {
      $(this).removeClass('load')
      return;
    }

    $.post('/Login/Index', credentials)
      .done(function(data) {
        window.location = '/Agenda'
      });
  });

  function getCredentials() {
    return {
      login: $('#login').val(),
      senha: $('#senha').val()
    }
  }

  function isValidOperation() {
    var login = $('#login').val()
    var senha = $('#senha').val()
    var isValid = true;

    if (!login) {
      isValid = false;
      toastr.error('Informe o Login.');
    }

    else if (!senha) {
      isValid = false;
      toastr.error('Informe a Senha.');
    }

    return isValid;
  }


})();
