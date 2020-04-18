import React from "react";
import {
  StyleSheet,
  View,
  Platform,
  Dimensions,
  SafeAreaView,
  Button,
} from "react-native";
import MapView, { Marker, AnimatedRegion } from "react-native-maps";
import Geolocation from '@react-native-community/geolocation';

import * as signalR from '@aspnet/signalr';

const { width, height } = Dimensions.get("window");

const ASPECT_RATIO = width / height;
const LATITUDE = 37.78825;
const LONGITUDE = -122.4324;
const LATITUDE_DELTA = 0.0922;
const LONGITUDE_DELTA = LATITUDE_DELTA * ASPECT_RATIO;

export default class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      hubConnection: null,
      latitude: LATITUDE,
      longitude: LONGITUDE,
      coordinate: new AnimatedRegion({
        latitude: LATITUDE,
        longitude: LONGITUDE,
        latitudeDelta: 0,
        longitudeDelta: 0
      })
    };
  };

  componentWillMount() {
    this.setState({
      hubConnection: new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:63819/tracking", {
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets,
        })
        .configureLogging(signalR.LogLevel.Debug)
        .build()
    });
  }

  componentDidMount() {
    this.state.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection', err));

    this.watchLocation();
  }

  componentDidUpdate(prevProps, prevState) {
    if (this.props.latitude !== prevState.latitude) {
      console.log("PROPS>>" + this.props.latitude + "|" + prevState.latitude)
      console.log("Hubconnection>>" + this.state.hubConnection);
    }
  }

  componentWillUnmount() {
    Geolocation.clearWatch(this.watchID);
  }

  watchLocation = () => {
    const { coordinate } = this.state;

    this.watchID = Geolocation.watchPosition(
      position => {
        const { latitude, longitude } = position.coords;
        console.log("WATCHLOCATION>>" + position.coords);

        const newCoordinate = {
          latitude,
          longitude
        };

        if (Platform.OS === "android") {
          if (this.marker) {
            this.marker._component.animateMarkerToCoordinate(
              newCoordinate,
              500 // 500 is the duration to animate the marker
            );
          }
        } else {
          coordinate.timing(newCoordinate).start();
        }

        this.setState({
          latitude,
          longitude
        });
      },
      error => console.log(error),
      {
        enableHighAccuracy: true,
        timeout: 20000,
        maximumAge: 1000,
        distanceFilter: 10
      }
    );
  };

  getMapRegion = () => ({
    latitude: this.state.latitude,
    longitude: this.state.longitude,
    latitudeDelta: LATITUDE_DELTA,
    longitudeDelta: LONGITUDE_DELTA
  });

  sendLocation() {
    this.state.hubConnection
      .invoke('sendToChannel', this.state.latitude, this.state.longitude)
      .catch(err => console.error(err));
  }

  render() {
    return (
      <SafeAreaView style={{ flex: 1 }}>
        <View style={styles.container}>
          <MapView
            style={styles.map}
            showUserLocation
            followUserLocation
            loadingEnabled
            region={this.getMapRegion()}
          >
            <Marker.Animated
              ref={marker => {
                this.marker = marker;
              }}
              coordinate={this.state.coordinate}
            />
          </MapView>
        </View>
        <View>
        <Button
            onPress={this.sendLocation.bind(this)}
            title="Send Location"
            color="#841584"
          />
        </View>
      </SafeAreaView>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    ...StyleSheet.absoluteFillObject,
    justifyContent: "flex-end",
    alignItems: "center"
  },
  map: {
    ...StyleSheet.absoluteFillObject
  }
});