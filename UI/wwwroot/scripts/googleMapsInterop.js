window.markers = [];

window.initMap = function (mapElement, zoom, buttonLabel, informWindow) {
    window.markers = [];
    let currentLocation = {lat: 10, lng: 10};
    
    window.map = new google.maps.Map(mapElement, {
        zoom: zoom,
        center: currentLocation,
    });

    const infoWindow = new google.maps.InfoWindow();
    const locationButton = document.createElement("button");

    locationButton.textContent = buttonLabel;
    locationButton.classList.add("custom-map-control-button");
    window.map.controls[google.maps.ControlPosition.TOP_CENTER].push(locationButton);
    locationButton.addEventListener("click", () => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    const pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                    };

                    infoWindow.setPosition(pos);
                    infoWindow.setContent(informWindow);
                    infoWindow.open(window.map);
                    window.map.setCenter(pos);
                },
                () => {
                    handleLocationError(true, infoWindow, window.map.getCenter());
                }
            );
        } else {
            handleLocationError(false, infoWindow, window.map.getCenter());
        }
    });

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude,
                };
                
                window.map.setCenter(pos);
            }
        );
    }
}

window.handleLocationError = function (browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(window.map);
}

window.initMapDefault = function () {
    const mapElement = document.getElementById("map");

    const currentLocation = {lat: 10.10, lng: 10.10};

    window.map = new google.maps.Map(mapElement, {
        zoom: 5,
        center: currentLocation,
    });
}

window.addMarker = function (contentString, displayName, lat, lng) {
    const location = {lat: lat, lng: lng};

    if (window.map == null) {
        window.initMap()
    }
    const infoWindow = new google.maps.InfoWindow({
        content: contentString,
        ariaLabel: displayName
    });
    const marker = new google.maps.Marker({
        position: location,
        map: window.map,
        title: displayName,
    });

    marker.addListener("click", () => {
        infoWindow.open({
            anchor: marker,
            map: window.map,
        });
    });
    
    window.markers.push(marker);
}

window.zoom = function (zoom, lat, long) {
    const pos = {
        lat: lat,
        lng: long,
    };
    window.map.setCenter(pos)
    window.map.setZoom(zoom)
}

window.redirectToPage = function (link) {
    window.location.assign(link);
}