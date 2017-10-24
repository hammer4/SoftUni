import toastr from 'toastr'

toastr.options = {
  'closeButton': true,
  'debug': false,
  'newestOnTop': true,
  'progressBar': true,
  'positionClass': 'toast-bottom-right',
  'preventDuplicates': false,
  'onclick': null,
  'showDuration': '3000',
  'hideDuration': '1000',
  'timeOut': '10000',
  'extendedTimeOut': '1000',
  'showEasing': 'swing',
  'hideEasing': 'linear',
  'showMethod': 'fadeIn',
  'hideMethod': 'fadeOut'
}

export default toastr
