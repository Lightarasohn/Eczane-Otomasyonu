import { InputNumber, Button, Form, Input, message } from "antd";
import { useState } from "react";
import "./SatisForm.css";

const SatisForm = ({ checkedList, setIsOpen, handleSubmit }) => {
  const [miktarData, setMiktarData] = useState({});

  const handleMiktarChange = (value, id) => {
    setMiktarData(prev => ({
      ...prev,
      [id]: value
    }));
  };

  const onFinish = (values) => {
    if (checkedList.length === 0) {
      message.error("Satış oluşturmak için en az 1 ilaç seçilmelidir.");
      return;
    }

    const result = {
      email: values.email,
      ilaclar: checkedList.map(item => ({
        ...item,
        miktar: miktarData[item.id] || 1
      }))
    };

    handleSubmit(result);
  };

  return (
    <Form layout="vertical" onFinish={onFinish}>
      <h1 style={{ fontSize: "30px" }}>Seçilen ilaçlar</h1>

      {checkedList.map((item) => (
        <div
          key={item.id}
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            marginBottom: "10px"
          }}
        >
          <li style={{ flex: 1 }}>{item.adi}</li>
          <li style={{ flex: 1, textAlign: "right" }}>
            Stok: {item.stokDurumu}
          </li>
          <li style={{ flex: 1, textAlign: "right", paddingRight: "40px" }}>
            Fiyat: {item.fiyati} TL
          </li>
          <li
            style={{
              flex: 1,
              display: "flex",
              justifyContent: "flex-end",
              alignItems: "center",
              gap: "5px"
            }}
          >
            <span>Miktar:</span>
            <InputNumber
              min={0}
              value={miktarData[item.id] || 1}
              onChange={(value) => handleMiktarChange(value, item.id)}
            />
          </li>
        </div>
      ))}

      <Form.Item
        name="email"
        label="Email"
        rules={[
          { required: true, message: "Email girilmelidir" },
          { type: "email", message: "Geçerli bir email girilmelidir" }
        ]}
      >
        <Input placeholder="ornek@eposta.com" />
      </Form.Item>

      <div style={{ display: "flex", justifyContent: "left", gap: "10px" }}>
        <Button type="primary" htmlType="submit">
          Satışı Oluştur
        </Button>
        <Button type="primary" danger onClick={() => setIsOpen(false)}>
          İptal
        </Button>
      </div>
    </Form>
  );
};

export default SatisForm;
