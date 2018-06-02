const _storageKey = "_stationUri";

let getStationUri = () => localStorage.getItem(_storageKey);
let setStationUri = (uri) => localStorage.setItem(_storageKey, uri);

