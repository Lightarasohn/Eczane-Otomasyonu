import { Button, Form, Input, InputNumber } from "antd";
import "./IlacAddForm.css";
import AddIlac from "../../api/AddIlac";

const IlacAddForm = ({
  setModalOpen,
  setResultModalOpen,
  setMessage,
  setIlaclar,
  ilaclar,
  setCheckedList,
}) => {
  const [form] = Form.useForm();

  const handleOnSubmit = async (values) => {
    const response = await AddIlac(values);
    if (response !== null) {
      const ilac = {
        id: response.id,
        adi: response.adi,
        fiyati: response.fiyati,
        stokDurumu: response.stokDurumu,
      };
      setIlaclar([...ilaclar, ilac]);

      if (setCheckedList) {
        setCheckedList([]);
      }

      setMessage("İlaç başarıyla eklendi.");
    } else {
      setMessage("İlaç eklenemedi.");
    }

    setModalOpen(false);
    setResultModalOpen(true);
    form.resetFields();
  };

  return (
    <>
      <Form
        form={form}
        onFinish={handleOnSubmit}
        style={{ justifyContent: "center" }}
      >
        <Form.Item
          label="İlaç Adı"
          name="adi"
          style={{ width: "300px" }}
          rules={[{ required: true, message: "İlaç adı girilmelidir" }]}
        >
          <Input placeholder="İlaç adı" />
        </Form.Item>

        <Form.Item
          label="Fiyat"
          name="fiyati"
          rules={[
            { required: true, message: "Fiyat girilmelidir" },
            {
              validator: (_, value) =>
                value > 0
                  ? Promise.resolve()
                  : Promise.reject("Fiyat 0'dan büyük olmalıdır"),
            },
          ]}
        >
          <InputNumber style={{ width: "100%" }} placeholder="10" />
        </Form.Item>

        <Form.Item
          label="Stok"
          name="stokDurumu"
          rules={[
            { required: true, message: "Stok girilmelidir" },
            {
              validator: (_, value) =>
                value > 0
                  ? Promise.resolve()
                  : Promise.reject("Stok 0'dan büyük olmalıdır"),
            },
          ]}
        >
          <InputNumber style={{ width: "100%" }} placeholder="100" />
        </Form.Item>

        <div style={{ display: "flex", gap: "10px" }}>
          <Button htmlType="submit" type="primary">
            İlaç Ekle
          </Button>
          <Button
            type="primary"
            danger
            onClick={() => {
              setModalOpen(false);
              form.resetFields();
            }}
          >
            Çık
          </Button>
        </div>
      </Form>
    </>
  );
};

export default IlacAddForm;
