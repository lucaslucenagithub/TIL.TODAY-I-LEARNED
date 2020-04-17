import React, { Component } from 'react';
import { Text, View } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Icon from 'react-native-vector-icons/FontAwesome';

import HomeScreen from '../pages/home/index';
import SettingsScreen from '../pages/settings/index';

export default class Routes extends Component {
    render() {

        const Tab = createBottomTabNavigator();

        return (
            <NavigationContainer>
                <Tab.Navigator>
                    <Tab.Screen
                        name="Home"
                        component={HomeScreen}
                        options={{
                            tabBarLabel: 'Home',
                            tabBarIcon: ({ color, size }) => (
                                <Icon name="home" color={color} size={size} />
                            )
                        }}
                    />
                    <Tab.Screen
                        name="Settings"
                        component={SettingsScreen}
                        options={{
                            tabBarLabel: 'Settings',
                            tabBarIcon: ({ color, size }) => (
                                <Icon name="cogs" color={color} size={size} />
                            )
                        }}
                    />
                </Tab.Navigator>
            </NavigationContainer>
        );
    };
};