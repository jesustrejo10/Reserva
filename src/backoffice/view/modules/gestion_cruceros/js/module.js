 $(document).ready(function () {
     $(".datepicker").datepicker();
 });
 openEdit = function (e) {
     e.preventDefault();
     console.log('a');
     $('#createCabin').modal('show');
 }
 $(".editCabin").click(function (event) {
     event.stopPropagation();
     event.preventDefault();
     $('#createCabin').modal('show');
 });