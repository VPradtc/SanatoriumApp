angular.module('DataAccessApp').factory('roomFormFactory',
    ['roomTypeDefinitionProvider', RoomFormFactory]);

function RoomFormFactory(roomTypeDefinitionProvider) {

    var _create = function () {

        var _fields = [
            {
                field: 'name',
                label: 'room.name',
                attrs: {
                    type: 'text',
                    name: 'name',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'room.nameIsRequired',
                    },
                ],
            },
            {
                field: 'roomTypeId',
                label: 'room.roomType',
                optionLabel: 'room.selectRoomType',
                attrs: {
                    type: 'select',
                    name: 'roomTypeId',
                    required: '',
                },
                dataSource: {
                    static: true,
                    data: roomTypeDefinitionProvider.getAll(),
                },
                options: {
                    dataTextField: 'name',
                    dataValueField: 'identifier',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'room.roomTypeIsRequired'
                    },
                ],
            },
            {
                field: 'capacity',
                label: 'room.capacity',
                attrs: {
                    type: 'number',
                    name: 'baseCost',
                    required: '',
                    min: '1',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'room.capacityIsRequired',
                    },
                ],
            },
        ];

        return _fields;
    }

    return {
        create: _create,
    }
}
