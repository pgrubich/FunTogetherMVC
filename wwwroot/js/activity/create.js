function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 52.406376, lng: 16.925167 },
        zoom: 13,
    });

    const input = document.getElementById("Location");
    const autocomplete = new google.maps.places.Autocomplete(input);

    autocomplete.bindTo("bounds", map);
    autocomplete.setFields(["address_components", "geometry", "name"]);

    const infowindow = new google.maps.InfoWindow();
    const infowindowContent = document.getElementById("infowindow-content");
    infowindow.setContent(infowindowContent);

    const marker = new google.maps.Marker({
        map,
        anchorPoint: new google.maps.Point(0, -29),
    });

    autocomplete.addListener("place_changed", () => {
        infowindow.close();
        marker.setVisible(false);
        const place = autocomplete.getPlace();

        if (!place.geometry) {
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }

        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17); 
        }
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);

        // Set address displayed on marker card
        let address = "";
        if (place.address_components) {
            address = [
                (place.address_components[1] &&
                    place.address_components[1].short_name) ||
                "",
                (place.address_components[0] &&
                    place.address_components[0].short_name) ||
                "",
                (place.address_components[3] &&
                    place.address_components[3].short_name) ||
                "",
            ].join(" ");
        }
        infowindowContent.children["place-name"].textContent = place.name;
        infowindowContent.children["place-address"].textContent = address;
        infowindow.open(map, marker);

        // Get city name from address components
        for (var i = place.address_components.length - 1; i >= 0; i--) {
            if (place.address_components[i].types.indexOf("locality") != -1) {
                document.getElementById("City").value = place.address_components[i].short_name;
            }
        }
       
        document.getElementById("LocationLatitude").value = place.geometry.location.lat();
        document.getElementById("LocationLongitude").value = place.geometry.location.lng(); 
    });

 
}