(function() {
  'use strict';
  var app = WinJS.Application;
  var activation = Windows.ApplicationModel.Activation;
  app.onactivated = function (args) {
    if (args.detail.kind === activation.ActivationKind.launch) {
      if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
        // TODO: This application has been newly launched. Initialize your application here.
          var t = UnitsNet.Temperature.fromDegreesCelsius(100);
          var unit = UnitsNet.Units.TemperatureUnit;
          document.getElementById('label').innerHTML = t.toString(unit.degreeCelsius) + ' = ' + t.toString(unit.degreeFahrenheit) + ' = ' + t.toString(unit.kelvin);
      } else {
        // TODO: This application has been reactivated from suspension.
        // Restore application state here.
      }
      args.setPromise(WinJS.UI.processAll().then(function() {
        // TODO: Your code here.
      }));
    }
  };
  app.oncheckpoint = function (args) {
    // TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
    // You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
    // If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
  };
  app.start();
}());
