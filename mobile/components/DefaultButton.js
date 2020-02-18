import React, { useState, useEffect } from 'react';
import { StyleSheet, View, Text, Image } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

export default function DefaultButton(props) {

    const { _roadmap } = props;

    return (
        <TouchableOpacity disabled={!props.enabled} style={{ alignItems: 'center' }} activeOpacity={0.5} onPress={props.onClick}>
            <View style={[props.enabled ? styles.buttonEnabled : styles.buttonDisabled, styles.button]}>
                <Text style={styles.buttonText}>{props.text}</Text>
            </View>
        </TouchableOpacity>
    );
}
const styles = StyleSheet.create({
    button: {
        alignItems: 'center',
        padding: 15,
        marginTop: 10,
        marginBottom: 10,
        borderRadius: 3
    },
    buttonEnabled: {
        backgroundColor: '#4d0250',
    },
    buttonDisabled: {
        backgroundColor: '#8f8f8f',
    },
    buttonText: {
        color: 'white'
    },
});

